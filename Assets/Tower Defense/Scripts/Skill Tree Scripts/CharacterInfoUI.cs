using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TowerDefense.Game;

public class CharacterInfoUI : MonoBehaviour
{
	[Header("Character")]
	public CharacterData.Role role;
	public string characterName;
	public Canvas statsPanel;
	public Text HPText, ATKText, DEFText, RESText, LVText;
	public Button refreshButton;

	[Header("Skills")]
	public Text skillNameText;
	public Text skillDescriptionText;
	public SkillButton[] skillButtons;

	protected Skill m_ActivateSkill = null;
	protected CharacterData m_Data;
	protected string m_CharacterStatus;

	public Skill ActivateSkill
	{
		get { return m_ActivateSkill; }
		set
		{
			m_ActivateSkill = value;
			if (m_ActivateSkill != null)
			{
				skillNameText.text = m_ActivateSkill.skillName;
				skillDescriptionText.text = m_ActivateSkill.skillDes;
				statsPanel.enabled = false;
			}
			else
			{
				skillNameText.text = characterName;
				skillDescriptionText.text = m_CharacterStatus;
				statsPanel.enabled = true;
			}
		}
	}

	public void Refresh()
	{
		m_Data = GameManager.instance.GetCharacterData(role);

		LVText.text = m_Data.LV.ToString();
		HPText.text = m_Data.HP.ToString();
		ATKText.text = m_Data.ATK.ToString();
		DEFText.text = m_Data.DEF.ToString();
		RESText.text = m_Data.RES.ToString();

		ActivateSkill = null;
	}

	protected void Awake()
	{
		var skillLibrary = GameManager.instance.GetCharacterSkillLibrary(role);
		for (int i = 0; i < skillButtons.Length; i++)
		{
			var skillButton = skillButtons[i];
			skillButton.CharacterInfoUI = this;
			skillButton.skill = skillLibrary.skills[i];
			skillButton.GetComponent<Image>().sprite = skillLibrary.skills[i].skillSprite;
		}
		refreshButton.onClick.AddListener(Refresh);
		m_CharacterStatus = skillDescriptionText.text;
	}
}
