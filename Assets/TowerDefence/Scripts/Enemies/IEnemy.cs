using System.Collections;
using System.Collections.Generic;
using TowerDefence.Level;
using UnityEngine;


namespace TowerDefence.Enemies
{
    public interface IEnemy
    {
        void StartMove(Track track);

        void Dispose();
    }
}

