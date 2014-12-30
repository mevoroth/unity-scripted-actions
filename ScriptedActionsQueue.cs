using UnityEngine;
using System.Collections;

public class ScriptedActionsQueue : MonoBehaviour
{
	public Queue m_actions = new Queue();

	IEnumerator ExecuteQueue()
	{
		for (;;)
		{
			while (m_actions.Count > 0)
			{
				ScriptedAction action = (ScriptedAction)m_actions.Dequeue();
				yield return new WaitForSeconds(action.PreWait);
				action.OnScriptedActionStart();
				for (float i = 0f, timer = action.ActionTimer, step = action.StepWait; i < timer; i += step)
				{
					action.Step(i / timer);
					yield return new WaitForSeconds(step);
				}
				action.Step(1f);
				action.OnScriptedActionFinished();
				Debug.Log(action.PostWait);
				yield return new WaitForSeconds(action.PostWait);
			}
			yield return new WaitForEndOfFrame();
		}
	}

	public void Awake()
	{
		StartCoroutine("ExecuteQueue");
	}

	public void Push(ScriptedAction action)
	{
		m_actions.Enqueue(action);
	}
}
