using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Enemies;
using TowerDefence.Towers;
using TowerDefence.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefence.Level
{
	public class Director : MonoBehaviour 
	{

		[SerializeField]
		private UIManager _uiManager;

		[SerializeField]
		private EnemySpawner _spawner;

		[SerializeField]
		private Stronghold _stronghold;

		[SerializeField]
		private BasicTower[] _debugTowers;

		private GameContext _context;
		private CompositionRoot _compositionRoot;

		private void Awake()
		{
			_context = new GameContext();

			ConfigureComposition();

			foreach (var tower in _debugTowers)
				tower.UpgradeRequired += TryUpgradeTower;

			Subscribe();
		}

		private void Start()
		{
			ConfigureContext();
			_compositionRoot.InvokePlayGame();
		}

		private void OnDestroy()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			_uiManager.RestartButtonDown += ReloadLevel;
			_spawner.EnemyCreated += SubscribeEnemyEvents;
			_stronghold.GotDamage += ApplyDamage;

			Root.Instance.StrongholdDestroyed += StopGame;
			Root.Instance.EnemyKilled += CountAndDisposeEnemy;

			_context.HealthChanged += PassAlognStrongholdHealthChanged;
			_context.GoldAmountChanged += PassAlongStrongholdGoldChanged;
			_context.StrongholdDestroyed += PassAlongStrongholdDestroyed;

			_compositionRoot.ObtainContext += GetContext;
		}

		private void Unsubscribe()
		{
			_uiManager.RestartButtonDown -= ReloadLevel;
			_spawner.EnemyCreated -= SubscribeEnemyEvents;
			_stronghold.GotDamage -= ApplyDamage;

			Root.Instance.StrongholdDestroyed -= StopGame;
			Root.Instance.EnemyKilled -= CountAndDisposeEnemy;

			_context.HealthChanged -= PassAlognStrongholdHealthChanged;
			_context.GoldAmountChanged -= PassAlongStrongholdGoldChanged;
			_context.StrongholdDestroyed -= PassAlongStrongholdDestroyed;

			_compositionRoot.ObtainContext -= GetContext;
		}


		private void ConfigureComposition()
		{
			_compositionRoot = new CompositionRoot();
			Root.SetInstance(_compositionRoot);
		}

		private void ConfigureContext()
		{
			_context.EnemiesDefeated = 0;
			var config = Root.Instance.Configuration.GetStrongholdConfiguration();

			_context.Gold = config.StartGold;
			_context.Health = config.StartHealth;
		}

		private void TryUpgradeTower(ITower tower)
		{
			var price = tower.GetUpgradePrice();

			if (price > _context.Gold)
				return;

			_context.Gold -= price;
			tower.Upgrade();
		}

		private IGameContext GetContext()
		{
			return _context;
		}

		private void ApplyDamage(int damage)
		{
			_context.Health -= damage;
		}

		private void CountAndDisposeEnemy(IEnemy enemy)
		{
			_context.EnemiesDefeated++;

			var reward = enemy.GetReward();
			_context.Gold += reward;

			enemy.Dispose();
		}

		private void StopGame()
		{
			_compositionRoot.InvokeStopGame();
		}

		private void PassAlongStrongholdGoldChanged(int gold)
		{
			_compositionRoot.InvokeGoldChanged(gold);
		}

		private void PassAlognStrongholdHealthChanged(int health)
		{
			_compositionRoot.InvokeHealthChanged(health);
		}

		private void PassAlongStrongholdDestroyed()
		{
			_compositionRoot.InvokeDestroyed();
		}

		private void SubscribeEnemyEvents(IEnemy enemy)
		{
			enemy.Died += PassAlongEnemyDied;
		}

		private void PassAlongEnemyDied(IEnemy enemy)
		{
			enemy.Died -= PassAlongEnemyDied;
			_compositionRoot.InvokeEnemyKilled(enemy);
		}

		private void ReloadLevel()
		{
			SceneManager.LoadSceneAsync(0);
		}


	} 
} 


