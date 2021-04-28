using System.Collections;
using System.Collections.Generic;
using TowerDefense.Game;
using UnityEngine;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour
{
	public CharacterData.Role role;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void EnableButton()
    {
        if (SkillManager.instance.GetCharacterInfo(role).ActivateSkill != null)
        {
            gameObject.SetActive(true);
            if (SkillManager.instance.characters[0].ActivateSkill.learnt)
			{
				GetComponent<Button>().interactable = false;
			}
            else
			{
				GetComponent<Button>().interactable = true;
			}
        }
        else
		{
			gameObject.SetActive(false);
		}
    }

	public void UnlockSkill()
	{
		if (SkillManager.instance.GetCharacterInfo(role).ActivateSkill != null)
		{
			SkillManager.instance.GetCharacterInfo(role).ActivateSkill.learnt = true;
		}
	}
}
