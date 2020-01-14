using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Configuration;
using TowerDefence.Enemies;
using UnityEngine;

namespace TowerDefence
{
	public interface IRoot 
	{
		event Action<IEnemy> EnemyKilled;
		event Action StrongholdDestroyed;

		event Action<int> StrongholdGoldChanged;
		event Action<int> StrongholdHealthChanged;

		IConfiguration Configuration { get; }
	
	} 
} 


