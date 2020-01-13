using System.Collections;
using System.Collections.Generic;
using TowerDefence.UI;
using UnityEngine;

namespace TowerDefence.Level
{
	public class Director : MonoBehaviour 
	{

		[SerializeField]
		private UIManager UIManager;

		[SerializeField]
		private EnemySpawner _spawner;

		[SerializeField]
		private Stronghold _stronghold;

		private CompositionRoot _compositionRoot;

		private void Awake()
		{
			_compositionRoot = new CompositionRoot();
			Root.SetInstance(_compositionRoot);
		}

		private void Start()
		{
			_stronghold.Activate();
			_spawner.StartSpawning();
		}
	} 
} 


