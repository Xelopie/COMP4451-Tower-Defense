using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActionGameFramework;
using TowerDefense.Affectors;

public class KnightAttackAffector : AttackAffector
{
    [Header("Customized attributes for Knight")]
    public Animator knightAnimator;
    public string attackParameter = "Attack";

    protected override void Update()
    {
        m_FireTimer -= Time.deltaTime;
        if (trackingEnemy != null && m_FireTimer <= 0.0f)
        {
            OnFireTimer();
            m_FireTimer = 1 / fireRate;
        }

    }

    protected override void OnFireTimer()
    {
        if (fireCondition != null)
        {
            if (!fireCondition())
            {
                return;
            }
        }

        if (m_TrackingEnemy != null && !knightAnimator.GetBool(attackParameter))
        {
            FireProjectile();
            knightAnimator.SetBool(attackParameter, true);
        }
    }
}
