using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvDisplay : MonoBehaviour
{
    public void OnDisplay()
    {
        LV.text = LvUpButton.previewLV.ToString();
    }
    
    public Text LV;
}
