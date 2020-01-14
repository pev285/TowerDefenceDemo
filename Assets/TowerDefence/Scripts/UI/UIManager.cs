using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.UI
{
    public class UIManager : MonoBehaviour
    {
        public event Action RestartButtonDown = () => { };

        [SerializeField]
        private GameObject _gameUI;
        [SerializeField]
        private GameObject _endgameUI;

        [SerializeField]
        private Button _RestartButton;

        private void Start()
        {
            var root = Root.Instance;

            root.GoldChanged += UpdateUI;
            root.HealthChanged += UpdateUI;
            root.StrongholdDestroyed += ShowEndgameUI;


            _RestartButton.onClick.AddListener(RestartButtonClickedListener);

            UpdateUI();
            ShowGameUI();
        }

        private void OnDestroy()
        {
            var root = Root.Instance;

            if (root == null)
                return;

            root.GoldChanged -= UpdateUI;
            root.HealthChanged -= UpdateUI;
            root.StrongholdDestroyed -= ShowEndgameUI;

            _RestartButton.onClick.RemoveListener(RestartButtonClickedListener);
        }

        private void UpdateUI(int value)
        {
            UpdateUI();
        }

        private void RestartButtonClickedListener()
        {
            RestartButtonDown();
        }

        private void ShowGameUI()
        {
            _gameUI.SetActive(true);
            _endgameUI.SetActive(false);
        }

        private void ShowEndgameUI()
        {
            var defeated = Root.Instance.Context.EnemiesDefeated;

            _gameUI.SetActive(false);
            _endgameUI.SetActive(true);

            Debug.Log($"::UI:: End of the Game, enemied={defeated}");
        }

        private void UpdateUI()
        {
            var context = Root.Instance.Context;

            Debug.Log($"::UI:: gold = {context.Gold}, health = {context.Health}");
        }

    }
}

