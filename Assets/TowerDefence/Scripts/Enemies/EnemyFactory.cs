using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefence.Enemies
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _enemyPrefabs;

        public IEnemy GetEnemy()
        {
            throw new NotImplementedException();
        }
    }
}

