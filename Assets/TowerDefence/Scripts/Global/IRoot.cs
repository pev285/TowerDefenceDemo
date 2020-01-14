using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Configuration;
using TowerDefence.Enemies;
using TowerDefence.Level;
using UnityEngine;

namespace TowerDefence
{
	public interface IRoot 
	{
		event Action<IEnemy> EnemyKilled;
		event Action StrongholdDestroyed;

		event Action<int> GoldChanged;
		event Action<int> HealthChanged;

		event Action PlayGame;
		event Action StopGame;

		IGameContext Context { get; }
		IConfiguration Configuration { get; }
	} 
} 


