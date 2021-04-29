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
	public Button closeButton;
	public Button unlockButton;
	public SkillButton[] skillButtons;

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
				skillPanel.enabled = true;

				unlockButton.gameObject.SetActive(true);
				if (ActivateSkill.learnt)
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

	public int previewHP
	{
		get { return int.Parse(previewHPText.text); }
		set
		{
			previewHPText.text = value.ToString();
		}
	}

	public int previewATK
	{
		get { return int.Parse(previewATKText.text); }
		set
		{
			previewATKText.text = value.ToString();
		}
	}

	public int previewDEF
	{
		get { return int.Parse(previewDEFText.text); }
		set
		{
			previewDEFText.text = value.ToString();
		}
	}

	public int previewRES
	{
		get { return int.Parse(previewRESText.text); }
		set
		{
			previewRESText.text = value.ToString();
		}
	}

	public int previewLV
	{
		get { return int.Parse(previewLVText.text); }
		set
		{
			previewLVText.text = value.ToString();
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
				levelUpButton.interactable = m_Data.LV == MAX_LEVEL ? false : true;
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
		previewHP += previewLV * 2;
		previewATK += previewLV * 3;
		previewDEF += previewLV * 2;
		previewRES += previewLV * 2;

		if (previewLV == MAX_LEVEL)
		{
			SetButtonState(PreviewState.PreviewMax);
		}
		else
		{
			SetButtonState(PreviewState.PreviewNormal);
		}
		
	}

	private void LevelDownPreview()
	{
		if (previewLV <= m_Data.LV) return;
		previewHP -= previewLV * 2;
		previewATK -= previewLV * 3;
		previewDEF -= previewLV * 2;
		previewRES -= previewLV * 2;
		previewLV -= 1;

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
	}

	/// <summary>
	/// Called by "Confirm Button" when leveling up
	/// </summary>
	private void ConfirmLevelUp()
	{
		var data = new CharacterData(role, previewLV, previewHP, previewATK, previewDEF, previewRES, 1);
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
		}
	}

	private void Start()
	{
		ReloadCharacterData();
		
		levelUpButton.onClick.AddListener(LevelUpPreview);
		levelDownButton.onClick.AddListener(LevelDownPreview);
		confirmButton.onClick.AddListener(ConfirmLevelUp);
		closeButton.onClick.AddListener(ResetActivateSkill);
		unlockButton.onClick.AddListener(UnlockSkill);

		Reset();

		foreach (var item in skillButtons)
		{
			item.CharacterLevelUpUI = this;
		}
	}

	public void Reset()
	{
		SetButtonState(PreviewState.Default);
		ResetPreview();
		ResetActivateSkill();
		skillPanel.enabled = false;
	}
}
