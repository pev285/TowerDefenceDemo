using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Towers;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.UI
{
	public class TowerUI : MonoBehaviour 
	{
		[SerializeField]
		private Text _text;
		[SerializeField]
		private BasicTower _tower;

		private void Awake()
		{
			UpdateText();
			_tower.CharacteristicsUpdated += UpdateText;
		}

		private void UpdateText()
		{
			_text.text = _tower.GetUpgradePrice().ToString();
		}
	} 
} 


