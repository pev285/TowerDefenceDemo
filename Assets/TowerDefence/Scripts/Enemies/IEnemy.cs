using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Level;
using UnityEngine;


namespace TowerDefence.Enemies
{
    public interface IEnemy : IDisposable
    {
        Vector3 GetPosition();
        void ApplyDamage(float amount);

        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);

        void SetLevel(int number);
        void StartMove(Track track);

        int GetDamage();
        int GetReward();
    }
}

