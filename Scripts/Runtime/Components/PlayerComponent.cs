using UnityEngine;

namespace Sterling.FirstPersonPlayer.Components
{
	public abstract class PlayerComponent : MonoBehaviour
	{
		protected FirstPersonController Controller;

		public void Initialize(FirstPersonController controller)
		{
			Controller = controller;
		}
		
		public abstract void OnUpdate();
	}
}