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
}
