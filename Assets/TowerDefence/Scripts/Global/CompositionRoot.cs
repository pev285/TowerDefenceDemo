using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Configuration;
using UnityEngine;

namespace TowerDefence
{
	public class CompositionRoot : MonoBehaviour, IRoot
	{
		private IConfiguration _configuration;
		public IConfiguration Configuration
		{
			get
			{
				if (_configuration == null)
					_configuration = new DebugConfiguration();

				return _configuration;
			}
		}
	}
} 


