using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TowerDefense.Game;

public class CharacterInfoUI : MonoBehaviour
{
	[TextArea(3, 10)]
	public string characterStatus;

	public CharacterData.Role role;
	public Sprite characterSprite;
	public string characterName;
	public Canvas infoPanel;
	public Text skillNameText;
	public Text skillDescriptionText;
	public Image skillImage;

	public Button[] skillButtons;

	protected Skill m_ActivateSkill = null;

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
				skillImage.sprite = m_ActivateSkill.skillSprite;
			}
			else
			{
				skillNameText.text = characterName;
				skillDescriptionText.text = characterStatus;
				skillImage.sprite = characterSprite;
			}
		}
	}

	protected void Awake()
	{
		foreach (var skillButton in skillButtons)
		{
			
		}	
	}
}
