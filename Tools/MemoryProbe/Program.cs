using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MemoryProbe
{
    class Program
    {
        const int PROCESS_VM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")] 
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, IntPtr dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", EntryPoint = "FindWindowA")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        static void Main(string[] args)
        {
            Console.WriteLine("MemoryProbe starting...");
            string target = null;
            int tx = 5597, ty = 1185;
            if (args.Length >= 1) target = args[0];
            if (args.Length >= 3)
            {
                int.TryParse(args[1], out tx);
                int.TryParse(args[2], out ty);
            }

            int pid = ResolvePid(target);
            if (pid <= 0)
            {
                Console.WriteLine("No PID resolved. Please provide PID or a window title.");
                return;
            }

            Console.WriteLine($"Using PID={pid} target={tx},{ty}");

            ScanForTargetCoordinates(pid, tx, ty);
            DiffScan(pid, 500);

            Console.WriteLine("Done.");
        }

        static int ResolvePid(string maybe)
        {
            if (string.IsNullOrEmpty(maybe))
            {
                // try common names
                var names = new[] { "ClassicUO", "uo", "client", "UOAssist" };
                foreach (var p in Process.GetProcesses())
                {
                    foreach (var n in names)
                    {
                        if (p.ProcessName.IndexOf(n, StringComparison.OrdinalIgnoreCase) >= 0)
                            return p.Id;
                    }
                }
                return -1;
            }
            int pid;
            if (int.TryParse(maybe, out pid)) return pid;
            // try to find window by title
            IntPtr hwnd = FindWindow(null, maybe);
            if (hwnd != IntPtr.Zero)
            {
                uint p; GetWindowThreadProcessId(hwnd, out p); return (int)p;
            }
            // try process name
            foreach (var p in Process.GetProcessesByName(maybe)) return p.Id;
            // try contains
            foreach (var p in Process.GetProcesses()) if (p.MainWindowTitle != null && p.MainWindowTitle.IndexOf(maybe, StringComparison.OrdinalIgnoreCase) >= 0) return p.Id;
            return -1;
        }

        static string HexDump(byte[] buf, int start, int len)
        {
            if (buf == null) return "";
            int end = Math.Min(buf.Length, start + len);
            StringBuilder sb = new StringBuilder();
            for (int i = start; i < end; i++)
            {
                sb.AppendFormat("{0:X2}", buf[i]);
                if ((i - start + 1) % 16 == 0) sb.Append(' ');
            }
            return sb.ToString();
        }

        static void ScanForTargetCoordinates(int pid, int targetX, int targetY)
        {
            Console.WriteLine("ScanForTargetCoordinates: starting");
            IntPtr hProc = OpenProcess(PROCESS_VM_READ, false, pid);
            if (hProc == IntPtr.Zero)
            {
                Console.WriteLine("OpenProcess failed"); return;
            }
            try
            {
                Process proc = Process.GetProcessById(pid);
                ushort tx = (ushort)targetX;
                ushort ty = (ushort)targetY;
                byte[] pattern16 = new byte[4];
                Array.Copy(BitConverter.GetBytes(tx), 0, pattern16, 0, 2);
                Array.Copy(BitConverter.GetBytes(ty), 0, pattern16, 2, 2);
                byte[] pattern32 = new byte[8];
                Array.Copy(BitConverter.GetBytes((int)targetX), 0, pattern32, 0, 4);
                Array.Copy(BitConverter.GetBytes((int)targetY), 0, pattern32, 4, 4);
                int matches = 0;
                const int CHUNK = 0x10000;
                byte[] buffer = new byte[CHUNK + 8];
                foreach (ProcessModule mod in proc.Modules)
                {
                    IntPtr baseAddr = mod.BaseAddress;
                    int size = mod.ModuleMemorySize;
                    int offset = 0;
                    while (offset < size)
                    {
                        int toRead = Math.Min(CHUNK, size - offset);
                        IntPtr br;
                        if (!ReadProcessMemory(hProc, baseAddr + offset, buffer, (IntPtr)toRead, out br))
                        {
                            offset += toRead; continue;
                        }
                        int rb = br.ToInt32();
                        for (int i = 0; i + pattern16.Length <= rb; i++)
                        {
                            bool ok = true; for (int k = 0; k < pattern16.Length; k++) if (buffer[i + k] != pattern16[k]) { ok = false; break; }
                            if (ok)
                            {
                                long addr = baseAddr.ToInt64() + offset + i;
                                int ds = Math.Max(0, i - 64); int dl = Math.Min(128, rb - ds);
                                Console.WriteLine($"TargetScan: 16-bit match at 0x{addr:X} -> {targetX},{targetY}");
                                Console.WriteLine(HexDump(buffer, ds, dl));
                                matches++; if (matches >= 16) break;
                            }
                        }
                        if (matches < 16)
                        {
                            for (int i = 0; i + pattern32.Length <= rb; i++)
                            {
                                bool ok = true; for (int k = 0; k < pattern32.Length; k++) if (buffer[i + k] != pattern32[k]) { ok = false; break; }
                                if (ok)
                                {
                                    long addr = baseAddr.ToInt64() + offset + i;
                                    int ds = Math.Max(0, i - 64); int dl = Math.Min(128, rb - ds);
                                    Console.WriteLine($"TargetScan: 32-bit match at 0x{addr:X} -> {targetX},{targetY}");
                                    Console.WriteLine(HexDump(buffer, ds, dl));
                                    matches++; if (matches >= 16) break;
                                }
                            }
                        }
                        offset += toRead; if (matches >= 16) break;
                    }
                    if (matches >= 16) break;
                }
                Console.WriteLine($"ScanForTargetCoordinates: matches={matches}");
            }
            catch (Exception ex) { Console.WriteLine("Scan exception: " + ex.Message); }
            finally { if (hProc != IntPtr.Zero) CloseHandle(hProc); }
        }

        static void DiffScan(int pid, int sampleDelayMs)
        {
            Console.WriteLine("DiffScan: starting");
            IntPtr hProc = OpenProcess(PROCESS_VM_READ, false, pid);
            if (hProc == IntPtr.Zero) { Console.WriteLine("OpenProcess failed"); return; }
            try
            {
                Process proc = Process.GetProcessById(pid);
                const int CHUNK = 0x10000;
                byte[] buffer = new byte[CHUNK + 8];
                var first = new Dictionary<long, ushort>();
                foreach (ProcessModule mod in proc.Modules)
                {
                    IntPtr baseAddr = mod.BaseAddress; int size = mod.ModuleMemorySize; int offset = 0;
                    while (offset < size)
                    {
                        int toRead = Math.Min(CHUNK, size - offset);
                        IntPtr br;
                        if (!ReadProcessMemory(hProc, baseAddr + offset, buffer, (IntPtr)toRead, out br)) { offset += toRead; continue; }
                        int rb = br.ToInt32();
                        for (int i = 0; i + 1 < rb; i += 2)
                        {
                            ushort v = BitConverter.ToUInt16(buffer, i);
                            long addr = baseAddr.ToInt64() + offset + i;
                            first[addr] = v;
                        }
                        offset += toRead;
                    }
                }
                Thread.Sleep(sampleDelayMs);
                int changes = 0;
                foreach (ProcessModule mod in proc.Modules)
                {
                    IntPtr baseAddr = mod.BaseAddress; int size = mod.ModuleMemorySize; int offset = 0;
                    while (offset < size)
                    {
                        int toRead = Math.Min(CHUNK, size - offset);
                        IntPtr br;
                        if (!ReadProcessMemory(hProc, baseAddr + offset, buffer, (IntPtr)toRead, out br)) { offset += toRead; continue; }
                        int rb = br.ToInt32();
                        for (int i = 0; i + 1 < rb; i += 2)
                        {
                            long addr = baseAddr.ToInt64() + offset + i;
                            ushort v2 = BitConverter.ToUInt16(buffer, i);
                            if (first.TryGetValue(addr, out ushort v1) && v1 != v2)
                            {
                                Console.WriteLine($"DiffScan: addr=0x{addr:X} {v1}->{v2}"); changes++; if (changes >= 32) break;
                            }
                        }
                        offset += toRead; if (changes >= 32) break;
                    }
                    if (changes >= 32) break;
                }
                Console.WriteLine($"DiffScan: changes={changes}");
            }
            catch (Exception ex) { Console.WriteLine("DiffScan exception: " + ex.Message); }
            finally { if (hProc != IntPtr.Zero) CloseHandle(hProc); }
        }
    }
}
