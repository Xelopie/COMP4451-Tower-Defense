using UnityEngine;
using TowerDefense.Affectors;

public class RangerAttackAffector : AttackAffector
{
    [Header("Customized attributes for Ranger")]
    public Animator rangerAnimator;

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
            rangerAnimator.SetTrigger("Attack");
        }
    }
}
