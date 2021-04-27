using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void EnableButton()
    {
        gameObject.SetActive(true);
    }

    // The following functions are called after entering lv up UI scene
    public void OnConfirm()
    {
        SkillManager.instance.characters[0].LV = LvUpButton.previewLV; SkillManager.instance.characters[0].EXPToLvUp = LvUpButton.previewEXPToLvUp;
        SkillManager.instance.characters[0].HP = LvUpButton.previewHP; SkillManager.instance.characters[0].ATK = LvUpButton.previewATK;
        SkillManager.instance.characters[0].DEF = LvUpButton.previewDEF; SkillManager.instance.characters[0].RES = LvUpButton.previewRES;
    }

    public void DisableButton()
    {
        if (SkillManager.instance.characters[0].activateSkill)
            GetComponent<Button>().interactable = false;
        else
            GetComponent<Button>().interactable = true;
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }

}
