using ActionGameFramework.Health;
using Core.Health;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.Targetting;
using UnityEngine;

/// <summary>
/// A special type of targetter which is used to target teammates
/// </summary>
public class TeamTargetter : Targetter
{
	public override void SearchForTarget()
	{
		m_CurrentTargetable = GetLowestHealthTargetable();
		OnSearchTarget();
	}

	protected override bool IsTargetableValid(Targetable targetable)
	{
		if (targetable == null)
		{
			return false;
		}

		IAlignmentProvider targetAlignment = targetable.configuration.alignmentProvider;
		bool canTarget = alignment == targetAlignment;

		return canTarget;
	}

	protected virtual Targetable GetLowestHealthTargetable()
	{
		int length = m_TargetsInRange.Count;

		if (length == 0)
		{
			return null;
		}

		Targetable lowestHp = null;
		float normalizedHp = 1.0f;
		for (int i = length - 1; i >= 0; i--)
		{
			Targetable targetable = m_TargetsInRange[i];
			if (targetable == null || targetable.isDead)
			{
				m_TargetsInRange.RemoveAt(i);
				continue;
			}
			float currentHp = targetable.configuration.normalisedHealth;
			if (currentHp < normalizedHp)
			{
				normalizedHp = currentHp;
				lowestHp = targetable;
			}
		}

		return lowestHp;
	}
}
