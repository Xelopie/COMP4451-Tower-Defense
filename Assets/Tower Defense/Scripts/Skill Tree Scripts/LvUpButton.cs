using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvUpButton : MonoBehaviour
{
    // function to call the lv up UI scene
    public void OnPressLvButton()
    {
        previewLV = SkillManager.instance.characters[0].LV; previewEXPToLvUp = SkillManager.instance.characters[0].EXPToLvUp;
        previewHP = SkillManager.instance.characters[0].HP; previewATK = SkillManager.instance.characters[0].ATK;
        previewDEF = SkillManager.instance.characters[0].DEF; previewRES = SkillManager.instance.characters[0].RES;
        // TODO call the lv up UI scene
    }

    // The following functions are called after entering lv up UI scene
    public void OnLvUp()
    {
        if (1000 >= previewEXPToLvUp)
        {
            // status preview
            previewLV += 1; previewEXPToLvUp += previewLV * 10; previewHP += previewLV * 2; previewATK += previewLV * 3;
            previewDEF += previewLV * 2; previewRES += previewLV * 2;
        }
    }

    public void DisableButton()
    {
        if (SkillManager.instance.characters[0].activateSkill)
            GetComponent<Button>().interactable = false;
        else
            GetComponent<Button>().interactable = true;
    }
    
    [NonSerialized]
    static public int previewLV = 0, previewEXPToLvUp = 0, previewHP = 0, previewATK = 0, previewDEF = 0, previewRES = 0;
}
