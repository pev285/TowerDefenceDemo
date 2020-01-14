using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace TowerDefence.Configuration.Json
{
	[CustomEditor(typeof(JsonConfigHolder))]
	public class JsonConfigHolderEditor : Editor
	{
		private const string ConfigPropertyName = "Config";

		private SerializedProperty _configHolder;

		private void OnEnable()
		{
			_configHolder = serializedObject.FindProperty(ConfigPropertyName);
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (GUILayout.Button("Save"))
				Save();

			if (GUILayout.Button("Load"))
				Load();
		}

		private void Save()
		{
			var configHolder = _configHolder.serializedObject.targetObject as JsonConfigHolder;
			var config = configHolder.Config;

			var json = JsonConvert.SerializeObject(config);

			var directory = JsonConfigPath.Directory;
			if (Directory.Exists(directory) == false)
				Directory.CreateDirectory(directory);

			File.WriteAllText(JsonConfigPath.FilePath, json);
			AssetDatabase.Refresh();
		}

		private void Load()
		{
			var json = File.ReadAllText(JsonConfigPath.FilePath);
			var config = JsonConvert.DeserializeObject<OverallConfiguration>(json);

			var configHolder = _configHolder.serializedObject.targetObject as JsonConfigHolder;
			configHolder.Config = config;
		}
	} 
} 


