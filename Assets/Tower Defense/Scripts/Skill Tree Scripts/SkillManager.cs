using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance; // Singleton Pattern

    public Sprite CharacterSprite;
    public string CharacterName;
    [TextArea(1, 3)]
    public string CharacterStatus;
    public Skill[] skills; // skills[0]
    public SkillButton[] skillButtons; // skillButtons[0]

    public Skill activateSkill;

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
        DontDestroyOnLoad(gameObject);
    }
}
