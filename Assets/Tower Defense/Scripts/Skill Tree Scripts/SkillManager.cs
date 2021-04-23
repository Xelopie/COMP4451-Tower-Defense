using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterInfo
{
	public Sprite characterSprite;
	public string characterName;
	public Canvas infoPanel;
	[NonSerialized]
	public Skill[] skills = new Skill[4]; // skills[0]
	[NonSerialized]
	public SkillButton[] skillButtons = new SkillButton[4]; // skillButtons[0]
	[NonSerialized]
	public Skill activateSkill;
}

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance; // Singleton Pattern

	[TextArea(3, 10)]
	public string characterStatus;

	public CharacterInfo[] characters;

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

		foreach (var characterInfo in characters)
		{
			characterInfo.skills[0] = characterInfo.infoPanel.transform.Find("Skill1").GetComponent<Skill>();
			characterInfo.skills[1] = characterInfo.infoPanel.transform.Find("Skill2").GetComponent<Skill>();
			characterInfo.skills[2] = characterInfo.infoPanel.transform.Find("Skill3").GetComponent<Skill>();
			characterInfo.skills[3] = characterInfo.infoPanel.transform.Find("Skill4").GetComponent<Skill>();
		}

		for (int i = 0; i < characters.Length; i++)
		{
			var characterInfo = characters[i];
			characterInfo.skillButtons[0] = characterInfo.infoPanel.transform.Find("Skill1").GetComponent<SkillButton>();
			characterInfo.skillButtons[1] = characterInfo.infoPanel.transform.Find("Skill2").GetComponent<SkillButton>();
			characterInfo.skillButtons[2] = characterInfo.infoPanel.transform.Find("Skill3").GetComponent<SkillButton>();
			characterInfo.skillButtons[3] = characterInfo.infoPanel.transform.Find("Skill4").GetComponent<SkillButton>();

			foreach (var item in characterInfo.skillButtons)
			{
				item.characterId = i;
			}
		}

		DontDestroyOnLoad(gameObject);
    }
}
