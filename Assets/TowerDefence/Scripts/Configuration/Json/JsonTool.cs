using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Configuration.Json
{
	public class JsonTool : MonoBehaviour 
	{
		public static string Serialize<T>(T obj)
		{
			return JsonUtility.ToJson(obj);
			//return JsonConvert.SerializeObject(obj);
		}

		public static T Deserialize<T>(string json)
		{
			return JsonUtility.FromJson<T>(json);
			//return JsonConvert.DeserializeObject<T>(json);
		}
	
	} 
} 


