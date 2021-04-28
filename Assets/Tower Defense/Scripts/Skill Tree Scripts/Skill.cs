using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skill
{
	public void UnlockSkill()
	{
		if (SkillManager.instance.characters[0].ActivateSkill != null)
		{
			if (!SkillManager.instance.characters[0].ActivateSkill.learnt)
				SkillManager.instance.characters[0].ActivateSkill.learnt = true;
		}
	}

	public string skillName;
	public Sprite skillSprite;

	[TextArea(1, 3)]
	public string skillDes;
	public bool learnt = false;
}

