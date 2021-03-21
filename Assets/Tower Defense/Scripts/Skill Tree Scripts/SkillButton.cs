using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Image skillImage;
    public Text skillNameText;
    public Text skillDesText;

    public int skillButtonId; // Each Button has one unique Button id correspond with the same order as the Skill array

    // This method will be called when we press each skill
    public void PressSkillButton()
    {
        Skill selectedSkill = transform.GetComponent<Skill>();

        if (!selectedSkill.isSelected)
        {
            SkillManager.instance.activateSkill = selectedSkill;

            skillImage.sprite = SkillManager.instance.skills[skillButtonId].skillSprite;
            skillNameText.text = SkillManager.instance.skills[skillButtonId].skillName;
            skillDesText.text = SkillManager.instance.skills[skillButtonId].skillDes;

            selectedSkill.isSelected = true;
        }
        else
        {
            SkillManager.instance.activateSkill = null;

            skillImage.sprite = SkillManager.instance.CharacterSprite;
            skillNameText.text = SkillManager.instance.CharacterName;
            skillDesText.text = SkillManager.instance.CharacterStatus;

            selectedSkill.isSelected = false;
        }
    }
}
