using ActionGameFramework.Health;
using System.Collections.Generic;
using TowerDefense.Affectors;
using UnityEngine;

public class HealerAttackAffector : AttackAffector
{
	[Header("Customized attributes for Healer")]
	public Animator healerAnimator;
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

		if (m_TrackingEnemy != null && m_TrackingEnemy.configuration.normalisedHealth < 1.0f && !healerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Heal"))
		{
			Invoke(nameof(FireProjectile), attackDelay);
			healerAnimator.SetTrigger("Single Heal");
		}
	}
}
