using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Configuration
{
	[Serializable]
	public struct TowerConfiguration 
	{
		public float Range;
		public float Damage;
		public float Frequency;

		[Space(10)]
		public int UpgradePricePerLevel;

		[Space(10)]
		public float RangePerLevelIncrement;
		public float DamagePerLevelIncrement;
		public float FrequencyPerLevelIncrement;
	} 
} 


