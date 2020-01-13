using System.Collections;
using System.Collections.Generic;
using TowerDefence.Enemies;
using TowerDefence.Towers;
using UnityEngine;

namespace TowerDefence.Configuration
{
	public interface IConfiguration 
	{
		EnemyConfiguration GetEnemyConfiguration(EnemyType type);
		TowerConfiguration GetTowerConfiguration(TowerType type);
	
		SpawnerConfiguration GetSpawnerConfiguration();
		StrongholdConfiguration GetStrongholdConfiguration();
	} 
} 


