using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }


    public void EnableButton()
    {
        if (SkillManager.instance.characters[0].activateSkill)
        {
            gameObject.SetActive(true);
            if (SkillManager.instance.characters[0].activateSkill.learnt)
                GetComponent<Button>().interactable = false;
            else
                GetComponent<Button>().interactable = true;
        }
        else
            gameObject.SetActive(false);
    }
}
