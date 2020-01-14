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
		public float RangeIncrement;
		public float DamageIncrement;
		public float FrequencyIncrement;

		[Space(10)]
		public int UpgradePrice;
		public int UpgradePreceIncrement;
	} 
} 


