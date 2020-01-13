using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Enemies;
using TowerDefence.Towers;
using UnityEngine;

namespace TowerDefence.Configuration
{
	[Serializable]
	public class OverallConfiguration : IConfiguration
	{
		public EnemyConfiguration EnemyConfig;
		public TowerConfiguration TowerConfig;

		public SpawnerConfiguration SpawnerConfig;
		public StrongholdConfiguration StrongholdConfig;

		public EnemyConfiguration GetEnemyConfiguration(EnemyType type)
		{
			return EnemyConfig;
		}

		public SpawnerConfiguration GetSpawnerConfiguration()
		{
			return SpawnerConfig;
		}

		public StrongholdConfiguration GetStrongholdConfiguration()
		{
			return StrongholdConfig;
		}

		public TowerConfiguration GetTowerConfiguration(TowerType type)
		{
			return TowerConfig;
		}
	}
} 


