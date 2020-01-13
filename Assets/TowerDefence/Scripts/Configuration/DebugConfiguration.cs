using System.Collections;
using System.Collections.Generic;
using TowerDefence.Enemies;
using TowerDefence.Towers;
using UnityEngine;

namespace TowerDefence.Configuration
{
	public class DebugConfiguration : OverallConfiguration
	{

		public DebugConfiguration()
		{
			//--- TODO: Real implementation using reading a file ---

			SpawnerConfig = new SpawnerConfiguration
			{
				WaveInterval = 3f,
				SpawnInterval = 0.5f,
				Spread = 2
			};

			EnemyConfig = new EnemyConfiguration
			{
				Health = 10,
				Damage = 2,
				Reward = 5,
				MoveSpeed = 3f,
				RotationSpeed = 360f
			};

			TowerConfig = new TowerConfiguration
			{
				Damage = 1,
				Frequency = 1f,

				DamagePerLevel = 1,
				FrequencyPerLevel = 1f,

				UpgradePricePerLevel = 50,
			};

			StrongholdConfig = new StrongholdConfiguration
			{
				StartGold = 100,
				StartHealth = 10
			};
		}

	}
} 


