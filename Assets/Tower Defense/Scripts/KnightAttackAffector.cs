using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActionGameFramework;
using TowerDefense.Affectors;

public class KnightAttackAffector : AttackAffector
{
    [Header("Customized attributes for Knight")]
    public Animator knightAnimator;
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

        if (m_TrackingEnemy != null && !knightAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
			Invoke(nameof(FireProjectile), attackDelay);
            knightAnimator.SetTrigger("Attack");
        }
    }
}
