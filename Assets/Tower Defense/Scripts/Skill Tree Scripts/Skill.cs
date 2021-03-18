using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skill Detail information
public class Skill : MonoBehaviour
{
    public string skillName;
    public Sprite skillSprite;

    [TextArea(1, 3)]
    public string skillDes;
    public bool isUpgrade;
}
