using System.Collections;
using System.Collections.Generic;
using TowerDefence.Configuration;
using TowerDefence.Enemies;
using UnityEngine;


namespace TowerDefence.Towers
{
    public class BasicTower : MonoBehaviour, ITower
    {
        private const float LaserBeamDuration = 0.1f;

        [SerializeField]
        private Transform _gun;
        [SerializeField]
        private LayerMask _enemyMask;

        [Space(10)]
        [SerializeField]
        private Transform _firePoint;
        [SerializeField]
        private LineRenderer _laserBeam;

        private int _level;

        private float _range;
        private float _damage;
        private float _fireInterval;

        private bool _isActivated;

        private IEnemy _currentEnemy;
        private float _timeSinceLastFire;

        private void Awake()
        {
            _laserBeam.positionCount = 0;
        }

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
            {
                if (_currentEnemy.IsAlive == false)
                {
                    _currentEnemy = null;
                }
                else
                {
                    float enemyDistance = Vector3.Distance(_currentEnemy.GetPosition(), _gun.position);
                    if (enemyDistance > _range)
                        _currentEnemy = null;
                }
            }

            if (_currentEnemy == null)
                _currentEnemy = FindEnemyInRange();
        }

        private IEnemy FindEnemyInRange()
        {
            var results = Physics.OverlapSphere(_gun.position, _range, _enemyMask);
            
            if (results.Length == 0)
                return null;

            //--- TODO: Select nearest? ---
            return results[0].GetComponentInParent<IEnemy>();
        }

        private void SetGunDirection()
        {
            if (_currentEnemy == null || _currentEnemy.IsAlive == false)
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

            StartCoroutine(ShowBeam(_firePoint.position, _currentEnemy.GetPosition()));
            _currentEnemy.ApplyDamage(_damage);
        }

        private IEnumerator ShowBeam(Vector3 start, Vector3 end)
        {
            _laserBeam.positionCount = 2;
            _laserBeam.SetPosition(0, start);
            _laserBeam.SetPosition(1, end);

            yield return new WaitForSeconds(LaserBeamDuration);
            _laserBeam.positionCount = 0;
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

            _range = config.Range + _level * config.RangeIncrement;
            _damage = config.Damage + _level * config.DamageIncrement;
            _fireInterval = 1.0f / (config.Frequency + _level * config.FrequencyIncrement);
        }

        private void OnMouseDown()
        {
            Debug.Log("Request Upgrade");
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _range);
        }

    }
}

