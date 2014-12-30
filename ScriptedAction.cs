using UnityEngine;
using System.Collections;

public class ScriptedAction : MonoBehaviour
{
	public float m_preWait = 0f;
	public float PreWait
	{
		get { return m_preWait; }
	}
	public float m_postWait = 0f;
	public float PostWait
	{
		get { return m_postWait; }
	}
	public float m_actionTimer = 1f;
	public float ActionTimer
	{
		get { return m_actionTimer; }
	}
	public float m_stepWait = 0.05f;
	public float StepWait
	{
		get { return m_stepWait; }
	}
	private float m_completion = 0f;
	public float Completion
	{
		get { return m_completion; }
	}
	public bool Finished
	{
		get { return m_completion == 1f; }
	}

	public virtual void Step(float completion)
	{
		m_completion = completion;
	}

	public virtual void OnScriptedActionFinished()
	{
	}

	public void OnScriptedActionStart()
	{
	}
}
