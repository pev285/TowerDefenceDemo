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

        public void StartSpawning(float waveInterval, float spawnInterval, int spread)
        {
            StartCoroutine(WavesStarterCoroutine(waveInterval, spawnInterval, spread));
        }

        public IEnumerator WavesStarterCoroutine(float waveInterval, float spawnInterval, int spread)
        {
            int waveNumber = 0;
            while (true)
            {
                waveNumber++;
                var enemiesCount = UnityEngine.Random.Range(waveNumber, waveNumber + spread + 1);

                yield return StartCoroutine(WaveCoroutine(spawnInterval, enemiesCount));
                yield return new WaitForSeconds(waveInterval);
            }
        }

        public IEnumerator WaveCoroutine(float spawnInterval, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var track = GetRandomTrack();
                var enemy = _factory.GetEnemy();

                enemy.StartMove(track);

                if(i < count-1)
                    yield return new WaitForSeconds(spawnInterval);
            }
        }

        private Track GetRandomTrack()
        {
            int index = UnityEngine.Random.Range(0, _tracks.Length);
            return _tracks[index];
        }
    }
}

