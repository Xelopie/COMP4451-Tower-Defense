using Core.Health;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour
{
    public Animator enemyAnimator;
    public DamageableBehaviour damageableBehaviour;

    public bool moveAnimation = true;
    public bool dieAnimation = true;
	public bool attackAnimation = true;

	// Return true if the attack animation can be triggered
	public bool TriggerAttack()
	{
		if (attackAnimation && !enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
		{
			enemyAnimator.SetTrigger("Attack");
			return true;
		}
		return false;
	}

    private void OnDied(DamageableBehaviour db)
    {
        enemyAnimator.SetTrigger("Dead");
    }

    private void Start()
    {
        if (dieAnimation)
        {
            damageableBehaviour.died += OnDied;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (moveAnimation)
        {
            var agent = GetComponent<NavMeshAgent>();
            var maxSpeed = agent.speed;
            var currentSpeed = agent.velocity.magnitude;
            enemyAnimator.SetFloat("Speed", currentSpeed / maxSpeed);
        }
    }
}
