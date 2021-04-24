using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Game
{
	[Serializable]
	public class CharacterData
	{
		public enum CharacterClass {
			Knight,
			Mage,
			Healer,
			Ranger,
			Support,
		}
		public CharacterClass characterClass;
		public int healthPoint = 100;
		public int attackDamage;
		public int defense;
		public int resistance;
		public int attackSpeed;
		public int cost;
		public int redeployTime;
		public int experience;

		public CharacterData(CharacterClass characterClass, int healthPoint, int attackDamage, int defense, int resistance, int attackSpeed, int cost, int redeployTime, int experience)
		{
			this.characterClass = characterClass;
			this.healthPoint = healthPoint;
			this.attackDamage = attackDamage;
			this.defense = defense;
			this.resistance = resistance;
			this.attackSpeed = attackSpeed;
			this.cost = cost;
			this.redeployTime = redeployTime;
			this.experience = experience;
		}
	}
}
