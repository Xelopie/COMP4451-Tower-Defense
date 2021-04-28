using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.Game;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
	public Skill skill;
	public CharacterData.Role role;

	// This method will be called when we press each skill
	public void PressSkillButton()
	{
		if (SkillManager.instance.GetCharacterInfo(role).ActivateSkill != skill)
		{
			SkillManager.instance.GetCharacterInfo(role).ActivateSkill = skill;
		}
		else
		{
			SkillManager.instance.GetCharacterInfo(role).ActivateSkill = null;
		}
	}

	// This method will be called when we press each skill for info display
	//public void InfoDisplay()
	//{
	//	if (CharacterInfoUI.instance.GetCharacterInfo(role).ActivateSkill != skill)
	//	{
	//		CharacterInfoUI.instance.GetCharacterInfo(role).ActivateSkill = skill;
	//	}
	//	else
	//	{
	//		CharacterInfoUI.instance.GetCharacterInfo(role).ActivateSkill = null;
	//	}
	//}

	private void Awake()
	{
		skill.skillSprite = GetComponent<Image>().sprite;
	}
}

