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

    private Transform m_targetTransform;

    void LateUpdate()
    {
        if (debugTargetTransform == null)
        {
            if (targetter.GetTarget() == null)
            {
                m_targetTransform = aimTransform;
            }
            else
            {
                m_targetTransform = targetter.GetTarget().targetableTransform;
            }
        } 
        else
        {
            m_targetTransform = debugTargetTransform;
        }

        Vector3 targetPosition = m_targetTransform.position;
        for (int i = 0; i < iterations; i++)
        {
            AimAtTarget(bone, targetPosition, weight);
        }
    }

    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight)
    {
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = targetPosition - aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion blendedRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, weight);
        bone.rotation = blendedRotation * bone.rotation;
    }
}
