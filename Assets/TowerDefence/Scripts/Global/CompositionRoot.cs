﻿using System;
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
                    LoadConfiguration();

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

        private bool _isPlaying = false;
        private event Action _playGame = () => { };
        private event Action _stopGame = () => { };

        public event Action PlayGame
        {
            add
            {
                if (_isPlaying)
                    value();

                _playGame += value;
            }

            remove
            {
                _playGame -= value;
            }
        }

        public event Action StopGame
        {
            add
            {
                if (_isPlaying == false)
                    value();

                _stopGame += value;
            }

            remove
            {
                _stopGame -= value;
            }
        }

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

        public void InvokePlayGame()
        {
            _isPlaying = true;
            _playGame();
        }

        public void InvokeStopGame()
        {
            _isPlaying = false;
            _stopGame();
        }

        private void LoadConfiguration()
        {
            //_configuration = new DebugConfiguration();
            _configuration = ConfigLoader.Load();
        }
    }
}


