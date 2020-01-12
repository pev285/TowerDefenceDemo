using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Level
{
    public class Track : MonoBehaviour, IEnumerable<Vector3>
    {
        [SerializeField]
        private Transform[] _wayPoints;

        public Vector3 GetStartPosition()
        {
            if (_wayPoints.Length == 0)
                return Vector3.zero;

            return _wayPoints[0].position;
        }

        public IEnumerator<Vector3> GetEnumerator()
        {
            foreach (var point in _wayPoints)
                yield return point.position;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

