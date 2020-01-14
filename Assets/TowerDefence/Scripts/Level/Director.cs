using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Enemies;
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

		private GameContext _context;
		private CompositionRoot _compositionRoot;

		private void Awake()
		{
			_compositionRoot = new CompositionRoot();
			Root.SetInstance(_compositionRoot);

			_context = new GameContext();
			_compositionRoot.ObtainContext += GetContext;

			Subscribe();
		}

		private void Start()
		{
			_context.EnemiesDefeated = 0;

			_spawner.Activate();
			_stronghold.Activate();
		}

		private void OnDestroy()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			_uiManager.RestartButtonDown += ReloadLevel;
			_spawner.EnemyCreated += SubscribeEnemyEvents;

			_stronghold.Died += PassAlongStrongholdDestroyed;
			_stronghold.HealthChanged += PassAlognStrongholdHealthChanged;
			_stronghold.GoldAmountChanged += PassAlongStrongholdGoldChanged;

			Root.Instance.StrongholdDestroyed += StopGame;
			Root.Instance.EnemyKilled += UpdateDefeatedEnemies;
		}

		private void Unsubscribe()
		{
			_uiManager.RestartButtonDown -= ReloadLevel;
			_spawner.EnemyCreated -= SubscribeEnemyEvents;

			_stronghold.Died -= PassAlongStrongholdDestroyed;
			_stronghold.HealthChanged -= PassAlognStrongholdHealthChanged;
			_stronghold.GoldAmountChanged -= PassAlongStrongholdGoldChanged;

			Root.Instance.StrongholdDestroyed -= StopGame;
			Root.Instance.EnemyKilled -= UpdateDefeatedEnemies;

			_compositionRoot.ObtainContext -= GetContext;
		}

		private IGameContext GetContext()
		{
			return _context;
		}

		private void UpdateDefeatedEnemies(IEnemy enemy)
		{
			_context.EnemiesDefeated++;
		}

		private void StopGame()
		{
			_spawner.Deactivate();
			_stronghold.Deactivate();
		}

		private void PassAlongStrongholdGoldChanged(int gold)
		{
			_compositionRoot.InvokeStrongholdGoldChanged(gold);
		}

		private void PassAlognStrongholdHealthChanged(int health)
		{
			_compositionRoot.InvokeStrongholdHealthChanged(health);
		}

		private void PassAlongStrongholdDestroyed()
		{
			_compositionRoot.InvokeStrongholdDestroyed();
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


