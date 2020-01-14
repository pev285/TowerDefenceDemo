using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Level
{
    public interface IGameContext
    {
        int Gold { get; }
        int Health { get; }
        int EnemiesDefeated { get; }

        event Action<int> HealthChanged;
        event Action StrongholdDestroyed;
        event Action<int> GoldAmountChanged;
    }
}


