using UnityEngine;

namespace FSM
{
	public class FiniteStateMachine : MonoBehaviour
	{
		public virtual void Exit ()
		{
			// code to execute when FSM is exited
			this.enabled = false;
		}

		public virtual void ReEnter ()
		{
			// code to execute when FSM is (re)entered
			this.enabled = true;
		}
	}
}