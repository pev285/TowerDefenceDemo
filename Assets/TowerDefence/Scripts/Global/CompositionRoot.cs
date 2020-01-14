using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Configuration;
using TowerDefence.Configuration.Json;
using TowerDefence.Enemies;
using TowerDefence.Level;
using TowerDefence.UI;
using UnityEngine;

namespace TowerDefence
{
	public class CompositionRoot :/* MonoBehaviour, */IRoot
	{
		private IConfiguration _configuration;
		public IConfiguration Configuration
		{
			get
			{
				if (_configuration == null)
					//_configuration = JsonConfigLoader.Load(JsonConfigPath.FilePath);
					_configuration = new DebugConfiguration();

				return _configuration;
			}
		}

		public event Action<IEnemy> EnemyKilled = (e) => { };
		public event Action StrongholdDestroyed = () => { };

		public event Action<int> StrongholdGoldChanged = (v) => { };
		public event Action<int> StrongholdHealthChanged = (v) => { };

		//private UIManager _ui;
		//private EnemySpawner _spawner;
		//private Stronghold _stronghold;

		//public event Func<UIManager> NeedUI;


		public void InvokeEnemyKilled(IEnemy enemy)
		{
			EnemyKilled(enemy);
		}

		public void InvokeStrongholdDestroyed()
		{
			StrongholdDestroyed();
		}

		public void InvokeStrongholdGoldChanged(int value)
		{
			StrongholdGoldChanged(value);
		}

		public void InvokeStrongholdHealthChanged(int value)
		{
			StrongholdHealthChanged(value);
		}
	}
} 


