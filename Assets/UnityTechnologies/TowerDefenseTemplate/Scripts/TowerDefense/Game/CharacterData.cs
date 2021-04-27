using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Game
{
	[Serializable]
	public class CharacterData
	{
		public enum Role {
			Knight,
			Mage,
			Healer,
			Ranger,
			Support,
		}
		public Role role;
		public float healthPoint = 100;
		public float attackDamage;
		public float defense;
		public float resistance;
		public float experience;

		public CharacterData(Role role, float healthPoint, float attackDamage, float defense, float resistance, float experience)
		{
			this.role = role;
			this.healthPoint = healthPoint;
			this.attackDamage = attackDamage;
			this.defense = defense;
			this.resistance = resistance;
			this.experience = experience;
		}

		public void SetCharacterData(CharacterData characterData)
		{
			if (characterData.role != role) return;
			this.healthPoint = characterData.healthPoint;
			this.attackDamage = characterData.attackDamage;
			this.defense = characterData.defense;
			this.resistance = characterData.resistance;
			this.experience = characterData.experience;
		}
	}
}
