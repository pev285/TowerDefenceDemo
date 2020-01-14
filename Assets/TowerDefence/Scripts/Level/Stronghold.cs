using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Enemies;
using UnityEngine;

namespace TowerDefence.Level
{
    public class Stronghold : MonoBehaviour
    {
        public event Action Died = () => { };

        public event Action<int> HealthChanged = (value) => { };
        public event Action<int> GoldAmountChanged = (value) => { };

        public int Gold { get; private set; }
        public int Health { get; private set; }

        private bool _isActivated;

        private void Awake()
        {
            Deactivate();
        }

        private void Start()
        {
            Configure();
            Root.Instance.EnemyKilled += TakeRewardAndDispose;
        }

        private void OnDestroy()
        {
            Root.Instance.EnemyKilled -= TakeRewardAndDispose;
        }

        private void TakeRewardAndDispose(IEnemy enemy)
        {
            var reward = enemy.GetReward();
            enemy.Dispose();

            ChangeGold(reward);
        }

        public void Activate()
        {
            _isActivated = true;
        }

        public void Deactivate()
        {
            _isActivated = false;
        }

        public void ChangeGold(int amount)
        {
            Gold += amount;
            GoldAmountChanged(Gold);
        }


        private void Configure()
        {
            var config = Root.Instance.Configuration.GetStrongholdConfiguration();
            Gold = config.StartGold;
            Health = config.StartHealth;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isActivated == false)
                return;

            var enemy = other.GetComponentInParent<IEnemy>();

            if (enemy == null)
                return;

            var damage = enemy.GetDamage();
            ApplyDamage(damage);

            enemy.Dispose();
        }

        private void ApplyDamage(int damage)
        {
            Health -= damage;

            if (Health < 0)
                Health = 0;

            HealthChanged(Health);

            if (Health == 0)
                Die();

            Debug.Log($"health = {Health}");
        }

        private void Die()
        {
            Deactivate();
            Died();
        }
    }
}

