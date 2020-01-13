using System.Collections;
using System.Collections.Generic;
using TowerDefence.Configuration;
using UnityEngine;


namespace TowerDefence.Towers
{
    public class BasicTower : MonoBehaviour, ITower
    {
        private int _level;

        private float _range;
        private float _damage;
        private float _fireInterval;

        private bool _isActivated;

        //private TowerConfiguration _config;

        private void Start()
        {
            _level = 0;
            Activate();
        }

        private void Update()
        {
            if (_isActivated == false)
                return;

            //--- Fire ---
        }

        public void Activate()
        {
            Configure();
            _isActivated = true;
        }

        public void Deactivate()
        {
            _isActivated = false;
        }

        public void Upgrade()
        {
            _level++;
            Configure();
        }

        private void Configure()
        {
            var config = Root.Instance.Configuration.GetTowerConfiguration(TowerType.BasicTower);

            _range = config.Range + _level * config.RangePerLevelIncrement;
            _damage = config.Damage + _level * config.DamagePerLevelIncrement;
            _fireInterval = 1.0f / (config.Frequency + _level * config.FrequencyPerLevelIncrement);
        }



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _range);
        }

    }
}

