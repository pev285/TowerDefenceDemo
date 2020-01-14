using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Level
{
    public class GameContext : IGameContext
    {
        public int EnemiesDefeated;

        public int GetDefeatedEnemiesCount()
        {
            return EnemiesDefeated;
        }
    }
}


