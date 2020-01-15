using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Configuration.Json
{
	public class ConfigPath : MonoBehaviour 
	{
		private const string _slash = "/";
		private const string _upDirectory = "../";

		private const string _fileExt = ".json";
		private const string _fileName = "Configuration";

		private const string _configFolderName = "Configuration/";
		private const string _projectAssetsFolderName = "TowerDefence/";

		private const string _fileNameExt = _fileName + _fileExt;

		public static string BuildLocalFilePath
		{
			get
			{
				return _slash + _configFolderName + _fileNameExt;
			}
		}

		public static string BuildDirectory
		{
			get
			{
				return Application.dataPath + _slash + _upDirectory + _configFolderName;
			}
		}

		public static string BuildFilePath
		{
			get
			{
				return BuildDirectory + _fileNameExt;
			}
		}

		public static string EditorDirectory
		{
			get
			{
				return Application.dataPath + _slash + _projectAssetsFolderName + _configFolderName;
			}
		}

		public static string EditorFilePath
		{
			get
			{
				return EditorDirectory + _fileNameExt;
			}
		}
	}
} 


