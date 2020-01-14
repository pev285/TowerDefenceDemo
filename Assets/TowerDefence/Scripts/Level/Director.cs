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

		private int _killedEnemiesCounter;
		private CompositionRoot _compositionRoot;

		private void Awake()
		{
			_compositionRoot = new CompositionRoot();
			Root.SetInstance(_compositionRoot);

			Subscribe();
		}

		private void Start()
		{
			_killedEnemiesCounter = 0;

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
		}

		private void StopGame()
		{
			_spawner.Deactivate();
			_stronghold.Deactivate();
		}

		private void Unsubscribe()
		{
			_uiManager.RestartButtonDown -= ReloadLevel;
			_spawner.EnemyCreated -= SubscribeEnemyEvents;

			_stronghold.Died -= PassAlongStrongholdDestroyed;
			_stronghold.HealthChanged -= PassAlognStrongholdHealthChanged;
			_stronghold.GoldAmountChanged -= PassAlongStrongholdGoldChanged;
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


