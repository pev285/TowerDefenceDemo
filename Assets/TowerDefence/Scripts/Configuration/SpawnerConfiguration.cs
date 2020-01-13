﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Configuration
{
	[Serializable]
	public class SpawnerConfiguration : MonoBehaviour 
	{
		public float WaveInterval;
		public float SpawnInterval;

		public int Spread;
	} 
} 

