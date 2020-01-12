using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Level;
using UnityEngine;


namespace TowerDefence.Enemies
{
    public class BasicEnemy : MonoBehaviour, IEnemy
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        // configure
        // - damage
        // - gold amount

        public void StartMove(Track track)
        {
            StartCoroutine(MoveCoroutine(track));
        }

        private IEnumerator MoveCoroutine(Track track)
        {
            foreach(var pos in track)
            {
                //StartCoroutine(RotateToCoroutine(pos));
                yield return StartCoroutine(RotateToCoroutine(pos));
                yield return StartCoroutine(MoveToCoroutine(pos));
            }
        }

        private IEnumerator RotateToCoroutine(Vector3 position)
        {
            throw new NotImplementedException();
        }

        private IEnumerator MoveToCoroutine(Vector3 position)
        {

            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

