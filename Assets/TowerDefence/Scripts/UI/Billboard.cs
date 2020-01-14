using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.UI
{
	public class Billboard : MonoBehaviour 
	{
		private Transform _camera;
		private Transform _transform;

		private void Awake()
		{
			_camera = Camera.main.transform;
			_transform = transform;
		}

		private void Update()
		{
			Vector3 direction = _camera.position - _transform.position;
			_transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
		}
	} 
} 


