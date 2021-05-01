using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skill
{
	public string skillName;
	public Sprite skillSprite;
	[TextArea(1, 3)]
	public string skillDes;

	/// <summary>
	/// This parameter will only be used in TitlePage scene for fast reference.
	/// In any other situation, you should refer to the data in .json file
	/// </summary>
	public bool learnt = false;

	private Skill m_Prerequisite;

	public Skill Prerequisite { get => m_Prerequisite; set => m_Prerequisite = value; }
}

