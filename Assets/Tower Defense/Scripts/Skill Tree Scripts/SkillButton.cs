using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.Game;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SkillButton : MonoBehaviour
{
	public Skill skill;

	private CharacterInfoUI m_CharacterInfoUI;
	private CharacterLevelUpUI m_CharacterLevelUpUI;

	public CharacterLevelUpUI CharacterLevelUpUI { get => m_CharacterLevelUpUI; set => m_CharacterLevelUpUI = value; }
	public CharacterInfoUI CharacterInfoUI { get => m_CharacterInfoUI; set => m_CharacterInfoUI = value; }

	// This method will be called when we press each skill for info display
	public void SetActivateSkill()
	{
		if (m_CharacterInfoUI)
		{
			m_CharacterInfoUI.ActivateSkill = (m_CharacterInfoUI.ActivateSkill != skill) ? skill : null;
		}

		if (m_CharacterLevelUpUI)
		{
			m_CharacterLevelUpUI.ActivateSkill = (m_CharacterLevelUpUI.ActivateSkill != skill) ? skill : null;
		}
	}

	private void Awake()
	{
		skill.skillSprite = GetComponent<Image>().sprite;
		GetComponent<Button>().onClick.AddListener(SetActivateSkill);
	}
}

