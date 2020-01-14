using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.UI
{
    [Serializable]
	public class MouseRegistrator : MonoBehaviour 
	{
        public event Action MouseUp = () => { };
        public event Action MouseDown = () => { };
        public event Action MouseDrag = () => { };

        private void OnMouseDown()
        {
            MouseDown();
        }

        private void OnMouseUp()
        {
            MouseUp();
        }

        private void OnMouseDrag()
        {
            MouseDrag();
        }
    } 
} 


