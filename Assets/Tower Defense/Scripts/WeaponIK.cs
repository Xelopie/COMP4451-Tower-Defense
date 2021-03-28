using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.Targetting;
using UnityEngine;

public class HumanBone
{
    public HumanBodyBones bone;
}

public class WeaponIK : MonoBehaviour
{
    [Header("Attributes for DEBUG (set to NULL when in-game)")]
    public Transform debugTargetTransform;

    [Header("Normal attributes (get target transform from targetter)")]
    public Targetter targetter;
    public Transform aimTransform;
    public Transform bone;
    [Range(1, 10)]
    public int iterations = 10;
    [Range(0, 1)]
    public float weight = 1.0f;

	/// <summary>
	/// DO NOT populate m_targetTransform, it is controlled by targetter/debugTargetTransform
	/// </summary>
    private Transform m_targetTransform;

	private void Start()
	{
		m_targetTransform = aimTransform;
	}

	/// <summary>
	/// All the update about weapon IK should be done after Update(), so use LateUpdate() here
	/// </summary>
	void LateUpdate()
    {
        if (debugTargetTransform)
        {
			m_targetTransform = debugTargetTransform;
        } 
        else
        {
			var target = targetter.GetTarget();
			if (target == null)
            {
				if (weight > 0f)
				{
					weight -= Time.deltaTime;
				}
				else
				{
					weight = 0f;
					m_targetTransform = aimTransform;
				}
            }
            else
            {
				if (weight < 1.0f)
				{
					weight += Time.deltaTime;
				}
				else
				{
					weight = 1f;
				}
				m_targetTransform = target.targetableTransform;
			}
        }

        for (int i = 0; i < iterations; i++)
        {
            AimAtTarget();
        }
    }

    private void AimAtTarget()
    {
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = m_targetTransform.position - aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion blendedRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, weight);
        bone.rotation = blendedRotation * bone.rotation;
    }
}
