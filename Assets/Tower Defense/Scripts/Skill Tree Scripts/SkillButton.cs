using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
	// This method will be called when we press each skill
	public void PressSkillButton()
	{
		Skill selectedSkill = transform.GetComponent<Skill>();

		if (SkillManager.instance.characters[0].activateSkill != selectedSkill)
		{
			SkillManager.instance.characters[0].activateSkill = selectedSkill;

			skillImage.sprite = SkillManager.instance.characters[0].skills[skillButtonId].skillSprite;
			skillNameText.text = SkillManager.instance.characters[0].skills[skillButtonId].skillName;
			skillDesText.text = SkillManager.instance.characters[0].skills[skillButtonId].skillDes;
		}
		else
		{
			SkillManager.instance.characters[0].activateSkill = null;

			skillImage.sprite = SkillManager.instance.characters[0].characterSprite;
			skillNameText.text = SkillManager.instance.characters[0].characterName;
			skillDesText.text = SkillManager.instance.characterStatus;
		}
	}

	public Image skillImage;
	public Text skillNameText;
	public Text skillDesText;

	public int skillButtonId; // Each Button has one unique Button id correspond with the same order as the Skill array
	public int characterId;
}

