using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SpawnEditor2
{
	[XmlRoot("SpawnEditorSetup")]
	public class SpawnEditorSetupFile
	{
		public int SchemaVersion = 1;

		public string ProfileName = string.Empty;

		public string RunUoExePath = string.Empty;

		public string UltimaClientExePath = string.Empty;

		public string MulFilesPath = string.Empty;

		public short ZoomLevel = -4;

		public string RunUoCmdPrefix = "[";

		public string SpawnName = "Spawn";

		public int SpawnHomeRange = 10;

		public int SpawnMaxCount = 1;

		public int SpawnMinDelay = 5;

		public int SpawnMaxDelay = 10;

		public int SpawnTeam = 0;

		public bool SpawnGroup = false;

		public bool SpawnRunning = true;

		public bool SpawnRelativeHome = true;

		public bool StartingStatics = false;

		public bool StartingDetails = false;

		public WorldMap StartingMap = WorldMap.Trammel;

		public bool StartingOnTop = false;

		public int StartingX = -1;

		public int StartingY = -1;

		public int StartingWidth = -1;

		public int StartingHeight = -1;

		public string TransferServerAddress = "127.0.0.1";

		public int TransferServerPort = 8030;
	}

	public class SetupProfileInfo
	{
		public SetupProfileInfo(string displayName, string filePath)
		{
			this.DisplayName = displayName;
			this.FilePath = filePath;
		}

		public string DisplayName { get; private set; }

		public string FilePath { get; private set; }
	}

	internal static class LocalSetupStorage
	{
		private const string ConfigFileName = "SpawnEditor.setup.xml";
		private const string LocatorFileName = "SpawnEditor.setup.path.txt";
		private const string ProfilesDirectoryName = "SpawnEditorProfiles";
		private const string ProfileFilePattern = "*.profile.xml";

		public static bool TryLoadConfiguration(string startupDirectory, out SpawnEditorSetupFile configuration, out string configurationPath)
		{
			configuration = null;
			configurationPath = null;
			foreach (string candidate in GetConfigurationCandidates(startupDirectory))
			{
				if (!File.Exists(candidate))
				{
					continue;
				}
				if (TryLoadFile(candidate, out configuration))
				{
					configurationPath = candidate;
					WriteLocator(startupDirectory, candidate);
					return true;
				}
			}
			return false;
		}

		public static bool TryLoadProfile(string filePath, out SpawnEditorSetupFile configuration)
		{
			configuration = null;
			if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
			{
				return false;
			}
			return TryLoadFile(filePath, out configuration);
		}

		public static void SaveConfiguration(string startupDirectory, string filePath, SpawnEditorSetupFile configuration)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new InvalidOperationException("Configuration file path is not available.");
			}
			SaveFile(filePath, configuration);
			WriteLocator(startupDirectory, filePath);
		}

		public static void SaveProfile(string filePath, SpawnEditorSetupFile configuration)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new InvalidOperationException("Profile file path is not available.");
			}
			SaveFile(filePath, configuration);
		}

		public static string GetConfigurationPath(string startupDirectory, string clientExePath, string loadedConfigurationPath)
		{
			string clientDirectory = GetClientDirectory(clientExePath);
			if (!string.IsNullOrEmpty(clientDirectory))
			{
				return Path.Combine(clientDirectory, ConfigFileName);
			}

			if (!string.IsNullOrEmpty(loadedConfigurationPath))
			{
				return loadedConfigurationPath;
			}

			return Path.Combine(startupDirectory, ConfigFileName);
		}

		public static string GetProfilesDirectory(string startupDirectory, string clientExePath, string loadedConfigurationPath)
		{
			string clientDirectory = GetClientDirectory(clientExePath);
			if (!string.IsNullOrEmpty(clientDirectory))
			{
				return Path.Combine(clientDirectory, ProfilesDirectoryName);
			}

			if (!string.IsNullOrEmpty(loadedConfigurationPath))
			{
				string loadedDirectory = Path.GetDirectoryName(loadedConfigurationPath);
				if (!string.IsNullOrEmpty(loadedDirectory))
				{
					return Path.Combine(loadedDirectory, ProfilesDirectoryName);
				}
			}

			return Path.Combine(startupDirectory, ProfilesDirectoryName);
		}

		public static List<SetupProfileInfo> GetProfiles(string startupDirectory, string clientExePath, string loadedConfigurationPath)
		{
			List<SetupProfileInfo> profiles = new List<SetupProfileInfo>();
			string profilesDirectory = GetProfilesDirectory(startupDirectory, clientExePath, loadedConfigurationPath);
			Directory.CreateDirectory(profilesDirectory);

			foreach (string filePath in Directory.GetFiles(profilesDirectory, ProfileFilePattern))
			{
				SpawnEditorSetupFile profile;
				if (!TryLoadFile(filePath, out profile))
				{
					continue;
				}

				string displayName = string.IsNullOrWhiteSpace(profile.ProfileName) ? Path.GetFileNameWithoutExtension(filePath) : profile.ProfileName.Trim();
				profiles.Add(new SetupProfileInfo(displayName, filePath));
			}

			profiles.Sort(delegate(SetupProfileInfo left, SetupProfileInfo right)
			{
				return string.Compare(left.DisplayName, right.DisplayName, StringComparison.OrdinalIgnoreCase);
			});
			return profiles;
		}

		private static IEnumerable<string> GetConfigurationCandidates(string startupDirectory)
		{
			string locatorPath = GetLocatorPath(startupDirectory);
			if (File.Exists(locatorPath))
			{
				string locatedConfig = File.ReadAllText(locatorPath).Trim();
				if (!string.IsNullOrEmpty(locatedConfig))
				{
					yield return locatedConfig;
				}
			}

			yield return Path.Combine(startupDirectory, ConfigFileName);
		}

		private static string GetLocatorPath(string startupDirectory)
		{
			return Path.Combine(startupDirectory, LocatorFileName);
		}

		private static string GetClientDirectory(string clientExePath)
		{
			if (string.IsNullOrWhiteSpace(clientExePath))
			{
				return null;
			}

			try
			{
				string fullPath = Path.GetFullPath(clientExePath);
				return Path.GetDirectoryName(fullPath);
			}
			catch
			{
				return null;
			}
		}

		private static bool TryLoadFile(string filePath, out SpawnEditorSetupFile configuration)
		{
			configuration = null;
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(SpawnEditorSetupFile));
				using (FileStream stream = File.OpenRead(filePath))
				{
					configuration = serializer.Deserialize(stream) as SpawnEditorSetupFile;
				}
				return configuration != null;
			}
			catch
			{
				return false;
			}
		}

		private static void SaveFile(string filePath, SpawnEditorSetupFile configuration)
		{
			string directory = Path.GetDirectoryName(filePath);
			if (!string.IsNullOrEmpty(directory))
			{
				Directory.CreateDirectory(directory);
			}

			XmlSerializer serializer = new XmlSerializer(typeof(SpawnEditorSetupFile));
			using (FileStream stream = File.Create(filePath))
			{
				serializer.Serialize(stream, configuration);
			}
		}

		private static void WriteLocator(string startupDirectory, string configurationPath)
		{
			try
			{
				File.WriteAllText(GetLocatorPath(startupDirectory), configurationPath ?? string.Empty);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to update the local setup locator file.\n" + ex.Message, "Setup Save Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}