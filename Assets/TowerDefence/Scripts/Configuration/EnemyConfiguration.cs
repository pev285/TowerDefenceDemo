using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Configuration
{
	[Serializable]
	public struct EnemyConfiguration 
	{
		public float Health;
		public int Damage;
		public int Reward;

		[Space(5)]
		public float HealthPerLevelIncrement;
		public int DamagePerLevelIncrement;
		public int RewardPerLevelIncrement;

		[Space(10)]
		public float MoveSpeed;
		public float RotationSpeed;

		[Space(5)]
		public float MoveSpeedPerLevelIncrement;
		public float RotationSpeedPerLevelIncrement;
	} 
} 


