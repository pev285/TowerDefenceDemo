﻿using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Level;
using UnityEngine;


namespace TowerDefence.Enemies
{
    public class BasicEnemy : MonoBehaviour, IEnemy
    {
        private Transform _transform;
        private Coroutine _rotationCoroutine;

        private int _health;
        private int _damage;
        private int _reward;

        private int _startHealth;
        private int _startDamage;
        private int _startReward;

        private int _healthPerLevelIncrement;
        private int _damagePerLevelIncrement;
        private int _rewardPerLevelIncrement;

        private float _moveSpeed;
        private float _rotationSpeed;

        private void Awake()
        {
            _transform = transform;
        }

        public void Configure()
        {
            var config = Root.Instance.Configuration.GetEnemyConfiguration(EnemyType.BasicEnemy);

            _health = config.Health;
            _damage = config.Damage;
            _reward = config.Reward;

            _startHealth = _health;
            _startDamage = _damage;
            _startReward = _reward;

            _healthPerLevelIncrement = config.HealthPerLevelIncrement;
            _damagePerLevelIncrement = config.DamagePerLevelIncrement;
            _rewardPerLevelIncrement = config.DamagePerLevelIncrement;

            _moveSpeed = config.MoveSpeed;
            _rotationSpeed = config.RotationSpeed;
        }

        public void StartMove(Track track)
        {
            Configure();
            StartCoroutine(MoveCoroutine(track));
        }

        private IEnumerator MoveCoroutine(Track track)
        {
            foreach(var pos in track)
            {
                _rotationCoroutine = StartCoroutine(RotateToCoroutine(pos));

                //yield return _rotationCoroutine;
                yield return StartCoroutine(MoveToCoroutine(pos));
            }
        }

        private IEnumerator RotateToCoroutine(Vector3 target)
        {
            Vector3 direction;
            do
            {
                var maxDegrees = _rotationSpeed * Time.deltaTime;

                var position = _transform.position;
                var rotation = _transform.rotation;

                var delta = target - position;
                var distance = delta.magnitude;

                if (distance == 0)
                    break;

                direction = delta.normalized;
                if (direction == _transform.forward)
                    break;

                var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                _transform.rotation = Quaternion.RotateTowards(rotation, targetRotation, maxDegrees);

                yield return null;
            } 
            while (true);
        }

        private IEnumerator MoveToCoroutine(Vector3 target)
        {
            do
            {
                var position = _transform.position;
                var maxStep = _moveSpeed * Time.deltaTime;

                var delta = target - position;
                var distance = delta.magnitude;

                if (distance <= maxStep)
                    break;

                var direction = delta.normalized;
                _transform.position = position + direction * maxStep;

                yield return null;
            } 
            while (true);

            _transform.position = target;
            StopCoroutine(_rotationCoroutine);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            _transform.rotation = rotation;
        }

        public void SetLevel(int level)
        {
            _health = _startHealth + level * _healthPerLevelIncrement;
            _damage = _startDamage + level * _damagePerLevelIncrement;
            _reward = _startReward + level * _rewardPerLevelIncrement;
        }
    }
}

