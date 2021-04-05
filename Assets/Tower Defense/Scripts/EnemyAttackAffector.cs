using System.Collections;
using System.Collections.Generic;
using TowerDefense.Affectors;
using UnityEngine;

public class EnemyAttackAffector : AttackAffector
{
	[Header("Customized attributes for Enemy")]
	public EnemyMoveController controller;
	public float attackDelay;

	protected override void OnFireTimer()
	{
		if (fireCondition != null)
		{
			if (!fireCondition())
			{
				return;
			}
		}

		if (m_TrackingEnemy != null)
		{
			if (controller.TriggerAttack())
			{
				Invoke(nameof(FireProjectile), attackDelay);
			}
		}
	}
}
