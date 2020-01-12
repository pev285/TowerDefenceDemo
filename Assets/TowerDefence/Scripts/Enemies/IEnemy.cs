using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Level;
using UnityEngine;


namespace TowerDefence.Enemies
{
    public interface IEnemy : IDisposable
    {
        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);

        void StartMove(Track track);
    }
}

