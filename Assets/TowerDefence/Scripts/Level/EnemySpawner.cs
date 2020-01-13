using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Enemies;
using UnityEngine;


namespace TowerDefence.Level
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyFactory _factory;

        [SerializeField]
        private Track[] _tracks;

        private float _waveInterval;
        private float _spawnInterval;

        private int _spread;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        //private void Start()
        //{
        //    StartSpawning();
        //}

        public void StartSpawning()
        {
            Configure();
            StartCoroutine(WavesStarterCoroutine(_waveInterval, _spawnInterval, _spread));
        }

        private IEnumerator WavesStarterCoroutine(float waveInterval, float spawnInterval, int spread)
        {
            int waveNumber = 0;
            while (true)
            {
                waveNumber++;
                var enemiesCount = UnityEngine.Random.Range(waveNumber, waveNumber + spread + 1);

                yield return StartCoroutine(WaveCoroutine(waveNumber, spawnInterval, enemiesCount));
                yield return new WaitForSeconds(waveInterval);

                UpdateEnemiesCharacteristics();
            }
        }

        private IEnumerator WaveCoroutine(int waveNumber, float spawnInterval, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IEnemy enemy = GetEnemy();
                enemy.SetLevel(waveNumber-1);

                var track = GetRandomTrack();
                enemy.StartMove(track);

                if (i < count - 1)
                    yield return new WaitForSeconds(spawnInterval);
            }
        }

        private IEnemy GetEnemy()
        {
            var enemy = _factory.GetEnemy();
            enemy.SetPosition(_transform.position);
            enemy.SetRotation(_transform.rotation);
            return enemy;
        }

        private Track GetRandomTrack()
        {
            int index = UnityEngine.Random.Range(0, _tracks.Length);
            return _tracks[index];
        }

        private void Configure()
        {
            var config = Root.Instance.Configuration.GetSpawnerConfiguration();

            _waveInterval = config.WaveInterval;
            _spawnInterval = config.SpawnInterval;

            _spread = config.Spread;
        }

        private void UpdateEnemiesCharacteristics()
        {
            //--- TODO --- !!!!!!!!!!!!!!!!!!!!!!!
        }


    }
}

