using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Game;
using Core.Utilities;
using TowerDefense.Towers;
using System;
using UnityEngine.Events;

[Serializable]
public class UnBindTower : UnityEvent<CharacterData.Role> { };

public class TowerManager : Singleton<TowerManager>
{
	public Tower[] towers;
	public UnBindTower onUnbindTower;
	public UnityEvent onChangeBinding;


	protected override void Awake()
	{
		base.Awake();

		towers = new Tower[Enum.GetValues(typeof(CharacterData.Role)).Length];
	}

	public void BindTower(CharacterData.Role role, Tower tower)
	{
		towers[(int)role] = tower;
		onChangeBinding.Invoke();
	}

	public void UnbindTower(CharacterData.Role role)
	{
		towers[(int)role] = null;
		onChangeBinding.Invoke();
		onUnbindTower.Invoke(role);
	}

	public bool IsCharacterAlive(CharacterData.Role role)
	{
		return towers[(int)role] != null;
	}
}
