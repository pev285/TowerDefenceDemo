using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Configuration.Json
{
	public class JsonConfigPath : MonoBehaviour 
	{
		private const string _fileName = "Configuration.json";
		private const string _directoryName = "/TowerDefence/Configuration/";

		public static string Directory
		{
			get
			{
				return Application.dataPath + _directoryName;
			}
		}

		public static string FilePath
		{
			get
			{
				return Directory + _fileName;
			}
		}
	}
} 


