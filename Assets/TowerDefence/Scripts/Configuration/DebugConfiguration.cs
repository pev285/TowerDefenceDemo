using System.Collections;
using System.Collections.Generic;
using TowerDefence.Enemies;
using TowerDefence.Towers;
using UnityEngine;

namespace TowerDefence.Configuration
{
	public class DebugConfiguration : IConfiguration
	{
		private EnemyConfiguration _enemy;
		private TowerConfiguration _tower;

		private SpawnerConfiguration _spawner;

		public DebugConfiguration()
		{
			//--- TODO: Real implementation using reading a file ---

			_spawner = new SpawnerConfiguration
			{
				WaveInterval = 3f,
				SpawnInterval = 0.5f,
				Spread = 2
			};

			_enemy = new EnemyConfiguration
			{
				Health = 10,
				Damage = 2,
				Reward = 5,
				MoveSpeed = 3f,
				RotationSpeed = 360f
			};

			_tower = new TowerConfiguration();
		}

		public EnemyConfiguration GetEnemyConfiguration(EnemyType type)
		{
			return _enemy;
		}

		public SpawnerConfiguration GetSpawnerConfiguration()
		{
			return _spawner;
		}

		public TowerConfiguration GetTowerConfiguration(TowerType type)
		{
			return _tower;
		}
	}
} 


