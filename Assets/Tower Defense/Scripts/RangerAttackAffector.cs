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

		Transform projectilePoint = projectilePoints[0];
		int layerMask = 1 << 11;
		layerMask = ~layerMask;
		if (m_TrackingEnemy != null && Physics.Raycast(projectilePoint.position, projectilePoint.forward, Mathf.Infinity, layerMask))
        {
            FireProjectile();
            rangerAnimator.SetTrigger("Attack");
        }
    }
}
