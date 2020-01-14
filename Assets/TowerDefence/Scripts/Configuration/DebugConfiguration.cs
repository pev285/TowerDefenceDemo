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
				RotationSpeed = 360f,

				MoveSpeedIncrement = 0.2f,
				RotationSpeedIncrement = 90,
			};

			TowerConfig = new TowerConfiguration
			{
				Range = 4f,
				Damage = 5,
				Frequency = 1f,

				RangeIncrement = 1f,
				DamageIncrement = 1,
				FrequencyIncrement = 1f,

				UpgradePrice = 50,
			};

			StrongholdConfig = new StrongholdConfiguration
			{
				StartGold = 100,
				StartHealth = 10
			};
		}

	}
} 


