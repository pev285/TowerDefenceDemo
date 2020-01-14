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

            root.StrongholdDestroyed += ShowEndgameUI;
            root.StrongholdGoldChanged += UpdateGoldUI;
            root.StrongholdHealthChanged += UpdateHealthUI;


            _RestartButton.onClick.AddListener(RestartButtonClickedListener);
            ShowGameUI();
        }

        private void OnDestroy()
        {
            var root = Root.Instance;

            if (root == null)
                return;

            root.StrongholdDestroyed += ShowEndgameUI;
            root.StrongholdGoldChanged += UpdateGoldUI;
            root.StrongholdHealthChanged += UpdateHealthUI;
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

        private void UpdateHealthUI(int health)
        {
            Debug.Log($"::UI:: health = {health}");
        }

        private void UpdateGoldUI(int gold)
        {
            //Debug.Log($"::UI:: gold = {gold}");
        }

        private void ShowEndgameUI()
        {
            _gameUI.SetActive(false);
            _endgameUI.SetActive(true);

            Debug.Log($"::UI:: End of the Game");
        }
    }
}

