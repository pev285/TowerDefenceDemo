using System.Collections;
using System.Collections.Generic;
using TowerDefence.Configuration;
using TowerDefence.Enemies;
using UnityEngine;


namespace TowerDefence.Towers
{
    public class BasicTower : MonoBehaviour, ITower
    {
        [SerializeField]
        private Transform _gun;
        [SerializeField]
        private LayerMask _enemyMask;

        private int _level;

        private float _range;
        private float _damage;
        private float _fireInterval;

        private bool _isActivated;

        //private Transform _transform;

        private IEnemy _currentEnemy;
        private float _timeSinceLastFire;
        //private TowerConfiguration _config;

        //private void Awake()
        //{
        //    _transform = transform;
        //}

        private void Start()
        {
            _level = 0;
            Activate();
        }

        private void Update()
        {
            _timeSinceLastFire += Time.deltaTime;

            if (_isActivated == false)
                return;

            UpdateEnemy();
            SetGunDirection();

            if (_timeSinceLastFire < _fireInterval)
                return;

            Fire();

            _timeSinceLastFire = 0;
        }

        private void UpdateEnemy()
        {
            if (_currentEnemy != null)
                if (Vector3.Distance(_currentEnemy.GetPosition(), _gun.position) > _range)
                    _currentEnemy = null;

            if (_currentEnemy == null)
                _currentEnemy = FindEnemy();
        }

        private IEnemy FindEnemy()
        {
            var results = Physics.OverlapSphere(_gun.position, _range, _enemyMask);
            
            if (results.Length == 0)
                return null;

            //--- TODO: Select nearest? ---
            return results[0].GetComponentInParent<IEnemy>();
        }

        private void SetGunDirection()
        {
            if (_currentEnemy == null)
                return;

            var enemyPosition = _currentEnemy.GetPosition();
            Vector3 direction = enemyPosition - _gun.position;

            var rotation = Quaternion.LookRotation(direction);
            _gun.rotation = rotation;
        }

        private void Fire()
        {
            if (_currentEnemy == null)
                return;

            // --- Draw line ---

            _currentEnemy.ApplyDamage(_damage);
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

