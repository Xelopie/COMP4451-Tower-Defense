using ActionGameFramework.Health;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.Targetting;
using UnityEngine;

public class DebugTargetter : MonoBehaviour
{
	public Targetter targetter;

	private Targetable m_targetable;

	private void Update()
	{
		var target = targetter.GetTarget();
		if (target != m_targetable)
		{
			m_targetable = target;
			Debug.Log(target);
		}
		
	}
}
