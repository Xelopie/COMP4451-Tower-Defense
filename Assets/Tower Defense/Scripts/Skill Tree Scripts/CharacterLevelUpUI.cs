using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Utilities;
using TowerDefense.Game;
using System;

public class CharacterLevelUpUI : MonoBehaviour
{
	const int MAX_LEVEL = 10;

	[Serializable]
	public enum PreviewState
	{
		Default,
		PreviewNormal,
		PreviewMax,
	}

	[Header("Preview")]
	public Canvas previewCanvas;
	public Text previewHPText, previewATKText, previewDEFText, previewRESText, previewLVText;

	[Header("EXP")]
	public Text currentEXPText;
	public Text requireEXPText;

	[Header("Character Current Stats")]
	public CharacterData.Role role;
	public Canvas currentStatsCanvas;
	public Text HPText, ATKText, DEFText, RESText, LVText;

	[Header("Interactable Buttons")]
	public Button confirmButton;
	public Button levelUpButton;
	public Button levelDownButton;

	[Header("Skill Tree")]
	public Canvas skillPanel;
	public Text skillNameText;
	public Text skillDescriptionText;
	public Text SPText;
	public Button closeButton;
	public Button unlockButton;
	public SkillButton[] skillButtons;

	protected Skill m_ActivateSkill = null;
	protected Image[] m_LockImages;

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
				skillPanel.enabled = true;

				unlockButton.gameObject.SetActive(true);
				if (ActivateSkill.learnt || SP < 1)
				{
					unlockButton.interactable = false;
				}
				else
				{
					unlockButton.interactable = true;
				}
			}
			else
			{
				skillPanel.enabled = false;
				unlockButton.gameObject.SetActive(false);
			}
		}
	}

	private PreviewState m_PreviewState;
	private CharacterData m_Data;

	private int previewHP
	{
		get { return int.Parse(previewHPText.text); }
		set
		{
			previewHPText.text = value.ToString();
		}
	}

	private int previewATK
	{
		get { return int.Parse(previewATKText.text); }
		set
		{
			previewATKText.text = value.ToString();
		}
	}

	private int previewDEF
	{
		get { return int.Parse(previewDEFText.text); }
		set
		{
			previewDEFText.text = value.ToString();
		}
	}

	private int previewRES
	{
		get { return int.Parse(previewRESText.text); }
		set
		{
			previewRESText.text = value.ToString();
		}
	}

	private int previewLV
	{
		get { return int.Parse(previewLVText.text); }
		set
		{
			previewLVText.text = value.ToString();
		}
	}

	private bool canLevelUp
	{
		get
		{
			return m_Data.LV != MAX_LEVEL && currentEXP >= requireEXP;
		}
	}

	private int currentEXP
	{
		get { return int.Parse(currentEXPText.text); }
		set
		{
			currentEXPText.text = value.ToString();
		}
	}

	private int requireEXP
	{
		get
		{
			int exp;
			if (int.TryParse(requireEXPText.text, out exp))
			{
				return exp;
			}
			else
			{
				return MAX_LEVEL * 100;
			}
		}
		set
		{
			if (value != MAX_LEVEL * 100)
			{
				requireEXPText.text = value.ToString();
			}
			else
			{
				requireEXPText.text = "MAX";
			}
		}
	}

	private int SP
	{
		get { return int.Parse(SPText.text); }
		set
		{
			SPText.text = value.ToString();
		}
	}

	/// <summary>
	/// Control related buttons' behaviours
	/// </summary>
	/// <param name="newState"></param>
	private void SetButtonState(PreviewState newState)
	{
		switch (newState)
		{
			case PreviewState.Default:
				ResetPreview();
				previewCanvas.enabled = false;
				currentStatsCanvas.enabled = true;
				levelDownButton.interactable = false;
				confirmButton.interactable = false;
				levelUpButton.interactable = canLevelUp ? true : false;
				break;
			case PreviewState.PreviewNormal:
				previewCanvas.enabled = true;
				levelUpButton.interactable = true;
				levelDownButton.interactable = true;
				confirmButton.interactable = true;
				break;
			case PreviewState.PreviewMax:
				previewCanvas.enabled = true;
				levelUpButton.interactable = false;
				levelDownButton.interactable = true;
				confirmButton.interactable = true;
				break;
			default:
				break;
		}
		m_PreviewState = newState;
	}

	private void LevelUpPreview()
	{
		if (previewLV >= MAX_LEVEL) return;
		previewLV += 1;
		previewHP += 10;
		previewATK += 1;
		previewDEF += 5;
		previewRES += 5;

		currentEXP -= requireEXP;
		requireEXP = previewLV * 100;

		if (canLevelUp)
		{
			SetButtonState(PreviewState.PreviewNormal);
		}
		else
		{
			SetButtonState(PreviewState.PreviewMax);
		}
		
	}

	private void LevelDownPreview()
	{
		if (previewLV <= m_Data.LV) return;
		previewHP -= 10;
		previewATK -= 1;
		previewDEF -= 5;
		previewRES -= 5;
		previewLV -= 1;

		requireEXP = previewLV * 100;
		currentEXP += requireEXP;

		if (previewLV == m_Data.LV)
		{
			SetButtonState(PreviewState.Default);
		}
		else
		{
			SetButtonState(PreviewState.PreviewNormal);
		}
	}

	/// <summary>
	/// Reload the data from file, update it to text fields
	/// </summary>
	private void ReloadCharacterData()
	{
		m_Data = GameManager.instance.GetCharacterData(role);

		LVText.text = m_Data.LV.ToString();
		HPText.text = m_Data.HP.ToString();
		ATKText.text = m_Data.ATK.ToString();
		DEFText.text = m_Data.DEF.ToString();
		RESText.text = m_Data.RES.ToString();

		currentEXP = (int)m_Data.EXP;
		requireEXP = m_Data.LV * 100;

		SP = m_Data.SP;

		for (int i = 0; i < 4; i++)
		{
			skillButtons[i].skill.learnt = m_Data.skills[i];
			if (skillButtons[i].skill.learnt)
			{
				m_LockImages[i].enabled = false;
			}
		}
	}

	/// <summary>
	/// Update preview level text fields
	/// </summary>
	private void ResetPreview()
	{
		previewLV = m_Data.LV;
		previewHP = (int)m_Data.HP;
		previewATK = (int)m_Data.ATK;
		previewDEF = (int)m_Data.DEF;
		previewRES = (int)m_Data.RES;

		currentEXP = (int)m_Data.EXP;
		requireEXP = m_Data.LV * 100;
	}

	/// <summary>
	/// Called by "Confirm Button" when leveling up
	/// </summary>
	private void ConfirmLevelUp()
	{
		int usedSP = 0;
		int rewardSP = 0;
		bool[] skills = new bool[4];
		for (int i = 0; i < skills.Length; i++)
		{
			skills[i] = skillButtons[i].skill.learnt;
			if (skills[i])
			{
				usedSP++;
			}
		}
		if (previewLV >= MAX_LEVEL)
		{
			rewardSP = 4 - usedSP;
		}
		else if (previewLV >= 9)
		{
			rewardSP = 3 - usedSP;
		}
		else if (previewLV >= 6)
		{
			rewardSP = 2 - usedSP;
		}
		else if (previewLV >= 3)
		{
			rewardSP = 1 - usedSP;
		}
		
		var data = new CharacterData(role, previewLV, previewHP, previewATK, previewDEF, previewRES, currentEXP, skills, rewardSP);
		GameManager.instance.SetCharacterData(data);

		ReloadCharacterData();
		SetButtonState(PreviewState.Default);
	}

	/// <summary>
	/// Called by "Close button" when displaying skill panel
	/// </summary>
	private void ResetActivateSkill()
	{
		ActivateSkill = null;
	}

	private void UnlockSkill()
	{
		if (ActivateSkill != null)
		{
			ActivateSkill.learnt = true;

			bool[] skills = new bool[4];
			for (int i = 0; i < skills.Length; i++)
			{
				skills[i] = skillButtons[i].skill.learnt;
			}

			var data = new CharacterData(role, m_Data.LV, m_Data.HP, m_Data.ATK, m_Data.DEF, m_Data.RES, m_Data.EXP, skills, SP - 1);

			GameManager.instance.SetCharacterData(data);
			ReloadCharacterData();
		}
	}

	private void Awake()
	{
		levelUpButton.onClick.AddListener(LevelUpPreview);
		levelDownButton.onClick.AddListener(LevelDownPreview);
		confirmButton.onClick.AddListener(ConfirmLevelUp);
		closeButton.onClick.AddListener(ResetActivateSkill);
		unlockButton.onClick.AddListener(UnlockSkill);

		m_LockImages = new Image[skillButtons.Length];
		for (int i = 0; i < skillButtons.Length; i++)
		{
			m_LockImages[i] = skillButtons[i].transform.Find("Lock").GetComponent<Image>();
		}

		foreach (var item in skillButtons)
		{
			item.CharacterLevelUpUI = this;
		}
	}

	private void Start()
	{
		ReloadCharacterData();

		Reset();
	}

	public void Reset()
	{
		SetButtonState(PreviewState.Default);
		ResetPreview();
		ResetActivateSkill();
		skillPanel.enabled = false;
	}
}
