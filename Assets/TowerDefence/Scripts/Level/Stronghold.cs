using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Enemies;
using UnityEngine;

namespace TowerDefence.Level
{
    public class Stronghold : MonoBehaviour
    {
        public event Action<int> GotDamage = (d) => { };

        private bool _isActivated;

        private void Awake()
        {
            Deactivate();
        }

        public void Activate()
        {
            _isActivated = true;
        }

        public void Deactivate()
        {
            _isActivated = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isActivated == false)
                return;

            var enemy = other.GetComponentInParent<IEnemy>();

            if (enemy == null)
                return;

            var damage = enemy.GetDamage();
            GotDamage(damage);

            enemy.Dispose();
        }
    }
}

