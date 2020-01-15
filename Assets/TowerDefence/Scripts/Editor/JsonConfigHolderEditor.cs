using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace TowerDefence.Configuration.Json
{
	[CustomEditor(typeof(ConfigHolder))]
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
			var configHolder = _configHolder.serializedObject.targetObject as ConfigHolder;
			var config = configHolder.Config;

			var json = JsonConvert.SerializeObject(config);
			var directory = ConfigPath.EditorDirectory;

			if (Directory.Exists(directory) == false)
				Directory.CreateDirectory(directory);

			File.WriteAllText(ConfigPath.EditorFilePath, json);
			AssetDatabase.Refresh();
		}

		private void Load()
		{
			var json = File.ReadAllText(ConfigPath.EditorFilePath);
			var config = JsonConvert.DeserializeObject<OverallConfiguration>(json);

			var configHolder = _configHolder.serializedObject.targetObject as ConfigHolder;
			configHolder.Config = config;
		}
	} 
} 


