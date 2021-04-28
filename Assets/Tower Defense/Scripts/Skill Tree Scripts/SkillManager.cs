using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TowerDefense.Game;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance; // Singleton Pattern

	[TextArea(3, 10)]
	public string characterStatus;

	public CharacterLevelUpInfo[] characters;

	public CharacterLevelUpInfo GetCharacterInfo(CharacterData.Role role)
	{
		foreach (var character in characters)
		{
			if (role == character.role)
			{
				return character;
			}
		}
		return null;
	}

	public void ResetAllActivateSkill()
	{
		foreach (var character in characters)
		{
			character.ActivateSkill = null;
		}
	}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
