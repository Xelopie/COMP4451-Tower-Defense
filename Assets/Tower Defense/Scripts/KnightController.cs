using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    public Animator knightAnimator;

    public void StartAttack()
    {
        knightAnimator.SetBool("Attack", true);
    }

    //private void Update()
    //{
    //    if (knightAnimator.GetBool("Attack"))
    //    {
    //        knightAnimator.SetBool("Attack", false);
    //    }
    //}
}
