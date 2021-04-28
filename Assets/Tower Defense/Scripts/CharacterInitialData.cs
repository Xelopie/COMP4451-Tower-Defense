using System.Collections;
using System.Collections.Generic;
using TowerDefense.Game;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData.asset", menuName = "TowerDefense/Character Data", order = 1)]
public class CharacterInitialData : ScriptableObject
{
	public CharacterData.Role role;
	public int LV;
	public float HP;
	public float ATK;
	public float DEF;
	public float RES;
	public float EXP;
}
