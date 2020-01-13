using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TowerDefence.Configuration.Json
{
	public class JsonConfigLoader : MonoBehaviour 
	{
		public static IConfiguration Load(string path)
		{
			var filePath = JsonConfigPath.FilePath;

			try
			{
				var json = File.ReadAllText(filePath);
				var config = JsonConvert.DeserializeObject<OverallConfiguration>(json);

				return config;
			}
			catch(Exception e)
			{
				return null;
			}
		}
	} 
} 


