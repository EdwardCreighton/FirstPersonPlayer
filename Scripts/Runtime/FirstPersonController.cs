using System;
using System.Collections.Generic;
using UnityEngine;
using Sterling.FirstPersonPlayer.Components;

namespace Sterling.FirstPersonPlayer
{
	public class FirstPersonController : MonoBehaviour
	{
		[SerializeField] private CharacterController characterController;
		[Space]
		[SerializeField] private List<PlayerComponent> components;

		private Dictionary<Type, PlayerComponent> _componentsDictionary;

		public CharacterController CharacterController => characterController;

		private void Awake()
		{
			_componentsDictionary = new Dictionary<Type, PlayerComponent>(components.Count);

			for (int i = 0; i < components.Count; i++)
			{
				_componentsDictionary.Add(components[i].GetType(), components[i]);
				
				components[i].Initialize(this);
			}
		}

		private void Update()
		{
			ForEachPlayerComponent((x) => x.OnUpdate());
		}

		private T GetPlayerComponent<T>() where T : PlayerComponent
		{
			_componentsDictionary.TryGetValue(typeof(T), out PlayerComponent component);
			return (T)component;
		}

		private void ForEachPlayerComponent(Action<PlayerComponent> action)
		{
			for (int i = 0; i < components.Count; i++)
			{
				action.Invoke(components[i]);
			}
		}
	}
}