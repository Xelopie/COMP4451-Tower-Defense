using System.Collections;
using System.Collections.Generic;
using TowerDefense.Game;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSkillLibrary.asset", menuName = "TowerDefense/Character Skill Library", order = 1)]
public class CharacterSkillLibrary : ScriptableObject
{
	public CharacterData.Role role;
	public Sprite[] skillSprites;
}
