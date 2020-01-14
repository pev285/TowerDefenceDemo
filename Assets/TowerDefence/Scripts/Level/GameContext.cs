using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Level
{
    public class GameContext : IGameContext
    {
        private int _gold;
        private int _health;
        private int _enemiesDefeated;

        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                _gold = value;
                GoldAmountChanged(_gold);
            }
        }
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
                HealthChanged(_health);

                if (_health <= 0)
                {
                    _health = 0;
                    StrongholdDestroyed();
                }
            }
        }
        public int EnemiesDefeated { get; set; }

        public event Action<int> HealthChanged = (h) => { };
        public event Action StrongholdDestroyed = () => { };
        public event Action<int> GoldAmountChanged = (g) => { };
    }
}


