using System.Collections;
using System.Collections.Generic;
using TowerDefense.Game;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData.asset", menuName = "TowerDefense/Character Data", order = 1)]
public class CharacterInitialData : ScriptableObject
{
	public CharacterData data;
}
