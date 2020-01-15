using System.Collections;
using System.Collections.Generic;
using System.IO;
using TowerDefence.Configuration.Json;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace TowerDefence.Build
{
	public class PostBuildActions : MonoBehaviour 
	{
		[PostProcessBuild]
		public static void CopyConfigInBuild(BuildTarget target, string pathToBuilt)
		{
			var sourcePath = ConfigPath.EditorFilePath;
			var destinationPath = Path.GetDirectoryName(pathToBuilt) + ConfigPath.BuildLocalFilePath; ;

			var destinationFolder = Path.GetDirectoryName(destinationPath);
			if (Directory.Exists(destinationFolder) == false)
				Directory.CreateDirectory(destinationFolder);

			Debug.Log($"Post Build:: copying from {sourcePath} to {destinationPath}");
			if (File.Exists(destinationPath))
				File.Delete(destinationPath);

			File.Copy(sourcePath, destinationPath);
		}
	} 
} 


