using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterInfo
{
	public Sprite characterSprite;
	public string characterName;
	public Transform infoPanel;
	[NonSerialized]
	public Skill[] skills = new Skill[4]; // skills[0]
	[NonSerialized]
	public SkillButton[] skillButtons = new SkillButton[4]; // skillButtons[0]
	[NonSerialized]
	public Skill activateSkill;
	[NonSerialized]
	public int LV, EXPToLvUp;
	[NonSerialized]
	public int HP, ATK, DEF, RES, DPCost, ReDP;
	[NonSerialized]
	public float ATKSPD;
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

		characters[0].LV = 1; characters[0].EXPToLvUp = 10; characters[0].HP = 500; characters[0].ATK = 100; characters[0].DEF = 50;
		characters[0].RES = 10;	characters[0].ATKSPD = 1.2f; characters[0].DPCost = 20; characters[0].ReDP = 60;

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
