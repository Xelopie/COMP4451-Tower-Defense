using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skill Detail information
public class Skill : MonoBehaviour
{    
    public void UnlockSkill()
    {
        if (SkillManager.instance.characters[0].activateSkill)
        {
            if (!SkillManager.instance.characters[0].activateSkill.learnt)
                SkillManager.instance.characters[0].activateSkill.learnt = true;
        }
    }

    public string skillName;
    public Sprite skillSprite;

    [TextArea(1, 3)]
    public string skillDes;
    public bool learnt = false;
}
