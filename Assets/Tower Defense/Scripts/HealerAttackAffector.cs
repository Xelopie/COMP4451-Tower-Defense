using System.Collections;
using System.Collections.Generic;
using TowerDefense.Affectors;
using UnityEngine;

public class HealerAttackAffector : AttackAffector
{
	[Header("Customized attributes for Healer")]
	public Animator healerAnimator;

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
			FireProjectile();
			healerAnimator.SetTrigger("Single Heal");
		}
	}
}
