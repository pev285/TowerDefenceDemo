using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefence
{
    public static class Root
    {

        private static IRoot _instance = null;
        public static IRoot Instance
        {
            get
            {
                if (_instance == null)
                    _instance = CreateInstance();

                return _instance;
            }
        }

        private static IRoot CreateInstance()
        {
            var go = new GameObject("CompositionRoot");
            return go.AddComponent<CompositionRoot>();
        }
    }
}

