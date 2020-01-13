using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Configuration
{
	[Serializable]
	public class TowerConfiguration 
	{
		public float Damage;
		public float Frequency;

		[Space(10)]
		public int UpgradePricePerLevel;

		[Space(10)]
		public float DamagePerLevel;
		public float FrequencyPerLevel;
	} 
} 


