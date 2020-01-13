using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Configuration
{
	[Serializable]
	public class EnemyConfiguration 
	{
		public int Health;
		public int Damage;
		public int Reward;

		[Space(10)]
		public int HealthPerLevelIncrement;
		public int DamagePerLevelIncrement;
		public int RewardPerLevelIncrement;

		[Space(10)]
		public float MoveSpeed;
		public float RotationSpeed;
	} 
} 


