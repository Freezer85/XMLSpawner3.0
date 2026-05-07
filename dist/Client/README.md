SpawnEditor2 — Deployment & Changes
=================================

Overview
--------
This repository contains a modified build of SpawnEditor2 (WinForms, .NET Framework 4.8) with server-driven tracking support and build automation to produce distributable artifacts under `dist\Client`.

What changed
------------
- Server-driven real-time tracking:
  - Added a poller that queries the TransferServer every 1 second for authenticated player position (`QueryAuthPosition` / `ReturnAuthPosition`).
  - Poller is gated by the `Track` flag / `chkTracking` UI checkbox.
  - Client no longer uses memory-scanning fallbacks; `TryGetLocationFromMemory` and related functions are disabled.
  - Blocking MessageBox popups for remote errors were removed; errors are logged to `spawneditor.log` and the `Track` flag is cleared on fatal remote errors.
- UI map repaint fix:
  - `DisplayMyLocation()` now forces `Invalidate()` + `Update()` on the map control so the position marker updates immediately on each poll.
- Server-side additions:
  - `QueryAuthPosition.ProcessMessage()` added server-side logging into `Scripts\Custom\TransServer\queryauth.log` (appended on invocation and response).
  - Server message type resolution gains an assembly fallback to reduce type-mismatch null responses.
- Build & distribution automation:
  - `SpawnEditor2.csproj` updated with a post-build target to copy outputs into `dist\Client`.
  - `build_and_copy.ps1` added to run the build and list `dist\Client` contents.
  - `auto_build_watcher.ps1` added to watch the repo and trigger `build_and_copy.ps1` automatically on source changes.

Where to find important files
----------------------------
- Client executable and artifacts: `dist\Client\SpawnEditor2.exe`, `SpawnEditor2.pdb`, `SpawnEditor2.exe.config`.
- Client log: `dist\Client\spawneditor.log` (rotated by app).
- Server script and logs: `dist\Server\Scripts\Custom\TransServer\QueryAuthPosition.cs` and `queryauth.log` (server-side — restart server after updating scripts).
- Build helper scripts: `build_and_copy.ps1`, `auto_build_watcher.ps1` (root of repository).

Deployment / Usage
------------------
1. Ensure `TransferServer` (TransServer) is running and listening on the configured address/port (default `127.0.0.1:8032`).
2. Authenticate the client session on the server using the server admin command (game-side):

   - Example: `XTS auth <SessionID>`

   The client sets `QueryAuthPosition.AuthenticationID = SessionID` when polling, so `AuthList` on the server must contain the same GUID.

3. Start `SpawnEditor2.exe` from `dist\Client`.
4. Enable `Track` using the UI checkbox to start server polling (poll interval: 1s).
5. Check `spawneditor.log` for client-side warnings and `Scripts\Custom\TransServer\queryauth.log` on the server for incoming poll logs and responses.

Build
-----
To build and copy artifacts to `dist\Client` locally run:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '.\build_and_copy.ps1'"
```

Or run the watcher to auto-build on change:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File ".\auto_build_watcher.ps1"
```

Notes & Troubleshooting
-----------------------
- If `dist\Client\SpawnEditor2.exe` cannot be overwritten during build, ensure no running instance of `SpawnEditor2.exe` exists (close it or stop the process). The build copies the executable on success.
- If client polls return `null` or errors, check `queryauth.log` on the server and verify the `SessionID` is present and not expired in `AuthList` (authentication lifetime is configured server-side).
- For server-side script changes, restart the TransferServer so the updated scripts are loaded.

Contact / Next steps
--------------------
If you want additional distribution packaging (ZIP of `dist\Client`), automatic installer creation, or a smaller change-log targeted at end-users, tell me and I can add those files and tasks.

Changelog (high level)
----------------------
- 2026-04-13: Implemented server poller, disabled memory scanning, replaced blocking popups with logs, added immediate map repaint, added build automation and server query logging.
