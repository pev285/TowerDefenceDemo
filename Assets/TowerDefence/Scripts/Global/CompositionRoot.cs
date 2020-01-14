using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Configuration;
using TowerDefence.Configuration.Json;
using TowerDefence.Enemies;
using TowerDefence.Level;
using TowerDefence.UI;
using UnityEngine;

namespace TowerDefence
{
    public class CompositionRoot : IRoot
    {
        private IConfiguration _configuration;
        public IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                    _configuration = JsonConfigLoader.Load(JsonConfigPath.FilePath);
                //_configuration = new DebugConfiguration();

                return _configuration;
            }
        }

        public Func<IGameContext> ObtainContext = () => null;
        public IGameContext Context
        {
            get
            {
                return ObtainContext();
            }
        }

        public event Action<IEnemy> EnemyKilled = (e) => { };
        public event Action StrongholdDestroyed = () => { };

        public event Action<int> GoldChanged = (v) => { };
        public event Action<int> HealthChanged = (v) => { };

        public void InvokeEnemyKilled(IEnemy enemy)
        {
            EnemyKilled(enemy);
        }

        public void InvokeDestroyed()
        {
            StrongholdDestroyed();
        }

        public void InvokeGoldChanged(int value)
        {
            GoldChanged(value);
        }

        public void InvokeHealthChanged(int value)
        {
            HealthChanged(value);
        }
    }
}


