using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TowerDefence.Configuration.Json
{
	public class ConfigLoader : MonoBehaviour 
	{
		public static IConfiguration Load()
		{
#if UNITY_EDITOR
			var filePath = ConfigPath.EditorFilePath;
#else
			var filePath = ConfigPath.BuildFilePath;
#endif

			try
			{
				var json = File.ReadAllText(filePath);
				var config = JsonConvert.DeserializeObject<OverallConfiguration>(json);

				return config;
			}
			catch(Exception e)
			{
				return new OverallConfiguration();
			}

		}
	} 
} 


