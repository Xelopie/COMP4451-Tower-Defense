using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.Game;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CharacterLevelUpInfo
{
	public CharacterData.Role role;
	public Sprite characterSprite;
	public string characterName;
	public Canvas infoPanel;
	public Text skillNameText;
	public Text skillDescriptionText;
	public Image skillImage;
	protected Skill m_ActivateSkill = null;

	public virtual Skill ActivateSkill
	{
		get { return m_ActivateSkill; }
		set
		{
			m_ActivateSkill = value;
			if (m_ActivateSkill != null)
			{
				skillNameText.text = m_ActivateSkill.skillName;
				skillDescriptionText.text = m_ActivateSkill.skillDes;
				skillImage.sprite = m_ActivateSkill.skillSprite;
				infoPanel.enabled = true;
			}
			else
			{
				infoPanel.enabled = false;
			}
		}
	}
}
