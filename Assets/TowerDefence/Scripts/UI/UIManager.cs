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
        private GameUI _gameUI;
        [SerializeField]
        private EndgameUI _endgameUI;

        [SerializeField]
        private Button _RestartButton;

        private void Start()
        {
            var root = Root.Instance;

            root.GoldChanged += UpdateGameUI;
            root.HealthChanged += UpdateGameUI;
            root.StrongholdDestroyed += ShowEndgameUI;


            _RestartButton.onClick.AddListener(RestartButtonClickedListener);

            UpdateGameUI();
            ShowGameUI();
        }

        private void OnDestroy()
        {
            var root = Root.Instance;

            if (root == null)
                return;

            root.GoldChanged -= UpdateGameUI;
            root.HealthChanged -= UpdateGameUI;
            root.StrongholdDestroyed -= ShowEndgameUI;

            _RestartButton.onClick.RemoveListener(RestartButtonClickedListener);
        }

        private void UpdateGameUI(int value)
        {
            UpdateGameUI();
        }

        private void RestartButtonClickedListener()
        {
            RestartButtonDown();
        }

        private void ShowGameUI()
        {
            UpdateGameUI();
            _gameUI.gameObject.SetActive(true);
            _endgameUI.gameObject.SetActive(false);
        }

        private void ShowEndgameUI()
        {
            var defeated = Root.Instance.Context.EnemiesDefeated;
            _endgameUI.EnemiesDefeatedText.text = defeated.ToString();

            _gameUI.gameObject.SetActive(false);
            _endgameUI.gameObject.SetActive(true);
        }

        private void UpdateGameUI()
        {
            var context = Root.Instance.Context;

            _gameUI.GoldValueText.text = context.Gold.ToString();
            _gameUI.HealthValueText.text = context.Health.ToString();
        }

    }
}

