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
	public enum ButtonState
	{
		Default,
		PreviewNormal,
		PreviewMax,
		SkillView
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

	private ButtonState m_ButtonState;
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

	public void SetButtonState(ButtonState newState)
	{
		switch (newState)
		{
			case ButtonState.Default:
				ResetPreview();
				previewCanvas.enabled = false;
				currentStatsCanvas.enabled = true;
				levelDownButton.interactable = false;
				confirmButton.interactable = false;
				levelUpButton.interactable = m_Data.LV == MAX_LEVEL ? false : true;
				break;
			case ButtonState.PreviewNormal:
				levelUpButton.interactable = true;
				levelDownButton.interactable = true;
				confirmButton.interactable = true;
				break;
			case ButtonState.PreviewMax:
				levelUpButton.interactable = false;
				levelDownButton.interactable = true;
				confirmButton.interactable = true;
				break;
			case ButtonState.SkillView:
				ResetPreview();
				previewCanvas.enabled = false;
				currentStatsCanvas.enabled = false;
				levelUpButton.interactable = false;
				levelDownButton.interactable = false;
				confirmButton.interactable = false;
				break;
			default:
				break;
		}
		m_ButtonState = newState;
	}

	public void LevelUpPreview()
	{
		if (previewLV >= MAX_LEVEL) return;
		previewLV += 1;
		previewHP += previewLV * 2;
		previewATK += previewLV * 3;
		previewDEF += previewLV * 2;
		previewRES += previewLV * 2;

		if (previewLV == MAX_LEVEL)
		{
			SetButtonState(ButtonState.PreviewMax);
		}
		else
		{
			SetButtonState(ButtonState.PreviewNormal);
		}
		
	}

	public void LevelDownPreview()
	{
		if (previewLV <= m_Data.LV) return;
		previewHP -= previewLV * 2;
		previewATK -= previewLV * 3;
		previewDEF -= previewLV * 2;
		previewRES -= previewLV * 2;
		previewLV -= 1;

		if (previewLV == m_Data.LV)
		{
			SetButtonState(ButtonState.Default);
		}
		else
		{
			SetButtonState(ButtonState.PreviewNormal);
		}
	}

	public void ResetPreview()
	{
		previewLV = m_Data.LV;
		previewHP = (int)m_Data.HP;
		previewATK = (int)m_Data.ATK;
		previewDEF = (int)m_Data.DEF;
		previewRES = (int)m_Data.RES;
	}

	public void ShowPreviewCanvas()
	{
		previewCanvas.enabled = true;
	}

	public void HidePreviewCanvas()
	{
		previewCanvas.enabled = false;
	}

	// The following functions are called after entering lv up UI scene
	public void ConfirmLevelUp()
	{
		var data = new CharacterData(role, previewLV, previewHP, previewATK, previewDEF, previewRES, 1);
		GameManager.instance.SetCharacterData(data);
		m_Data = GameManager.instance.GetCharacterData(role);

		LVText.text = m_Data.LV.ToString();
		HPText.text = m_Data.HP.ToString();
		ATKText.text = m_Data.ATK.ToString();
		DEFText.text = m_Data.DEF.ToString();
		RESText.text = m_Data.RES.ToString();

		SetButtonState(ButtonState.Default);
	}

	private void ChangeToSkillView()
	{
		SetButtonState(ButtonState.SkillView);
	}

	private void Start()
	{
		m_Data = GameManager.instance.GetCharacterData(role);

		SetButtonState(ButtonState.Default);

		LVText.text = m_Data.LV.ToString();
		HPText.text = m_Data.HP.ToString();
		ATKText.text = m_Data.ATK.ToString();
		DEFText.text = m_Data.DEF.ToString();
		RESText.text = m_Data.RES.ToString();

		previewLV = m_Data.LV;
		previewHP = (int)m_Data.HP;
		previewATK = (int)m_Data.ATK;
		previewDEF = (int)m_Data.DEF;
		previewRES = (int)m_Data.RES;

		levelUpButton.onClick.AddListener(ShowPreviewCanvas);
		levelUpButton.onClick.AddListener(LevelUpPreview);
		levelDownButton.onClick.AddListener(LevelDownPreview);
		confirmButton.onClick.AddListener(ConfirmLevelUp);
	}
}
