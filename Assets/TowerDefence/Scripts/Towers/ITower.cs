using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefence.Towers
{
    public interface ITower
    {
        void Upgrade();
        int GetUpgradePrice();

        event Action CharacteristicsUpdated;
    }
}

