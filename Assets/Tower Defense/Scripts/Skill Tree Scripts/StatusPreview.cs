using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPreview : MonoBehaviour
{
    public void OnUpdate()
    {
        HP.text = LvUpButton.previewHP.ToString();
        ATK.text = LvUpButton.previewATK.ToString();
        DEF.text = LvUpButton.previewDEF.ToString();
        RES.text = LvUpButton.previewRES.ToString();
    }

    public Text HP, ATK, DEF, RES;
}
