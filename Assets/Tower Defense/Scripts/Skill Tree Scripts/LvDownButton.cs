using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvDownButton : MonoBehaviour
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
    public void OnLvDown()
    {
        if (LvUpButton.previewLV >= SkillManager.instance.characters[0].LV)
        {
            // status preview
            LvUpButton.previewEXPToLvUp -= LvUpButton.previewLV * 10; LvUpButton.previewHP -= LvUpButton.previewLV * 2; LvUpButton.previewATK -= LvUpButton.previewLV * 3;
            LvUpButton.previewDEF -= LvUpButton.previewLV * 2; LvUpButton.previewRES -= LvUpButton.previewLV * 2; LvUpButton.previewLV -= 1;
        }
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
