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
	public bool learnt = false;

	private Skill m_Prerequisite;

	public Skill Prerequisite { get => m_Prerequisite; set => m_Prerequisite = value; }
}

