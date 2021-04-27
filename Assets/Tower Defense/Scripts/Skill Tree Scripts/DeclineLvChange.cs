using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclineLvChange : MonoBehaviour
{
    // The following functions if player didn't confirm LvUp and left the scene
    public void Decline()
    {
        LvUpButton.previewLV = SkillManager.instance.characters[0].LV; LvUpButton.previewEXPToLvUp = SkillManager.instance.characters[0].EXPToLvUp;
        LvUpButton.previewHP = SkillManager.instance.characters[0].HP; LvUpButton.previewATK = SkillManager.instance.characters[0].ATK;
        LvUpButton.previewDEF = SkillManager.instance.characters[0].DEF; LvUpButton.previewRES = SkillManager.instance.characters[0].RES;
    }
}
