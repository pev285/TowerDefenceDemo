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
		public float HealthIncrement;
		public int DamageIncrement;
		public int RewardIncrement;

		[Space(10)]
		public float MoveSpeed;
		public float RotationSpeed;

		[Space(5)]
		public float MoveSpeedIncrement;
		public float RotationSpeedIncrement;
	} 
} 


