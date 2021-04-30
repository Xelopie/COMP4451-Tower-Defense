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
		public int LV;
		public float HP;
		public float ATK;
		public float DEF;
		public float RES;
		public float EXP;

		public CharacterData(Role role, int LV, float HP, float ATK, float DEF, float RES, float EXP)
		{
			this.role = role;
			this.LV = LV;
			this.HP = HP;
			this.ATK = ATK;
			this.DEF = DEF;
			this.RES = RES;
			this.EXP = EXP;
		}

		public CharacterData(CharacterData data)
		{
			this.role = data.role;
			this.LV = data.LV;
			this.HP = data.HP;
			this.ATK = data.ATK;
			this.DEF = data.DEF;
			this.RES = data.RES;
			this.EXP = data.EXP;
		}

		public void SetCharacterData(CharacterData data)
		{
			if (data.role != role) return;
			this.LV = data.LV;
			this.HP = data.HP;
			this.ATK = data.ATK;
			this.DEF = data.DEF;
			this.RES = data.RES;
			this.EXP = data.EXP;
		}
	}
}
