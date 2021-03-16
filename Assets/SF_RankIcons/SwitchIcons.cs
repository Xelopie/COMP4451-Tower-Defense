using System;
using UnityEngine;
using UnityEngine.UI;

public class SwitchIcons : MonoBehaviour
{
    public Sprite[] blue;
    public Sprite[] green;
    public Sprite[] orange;
    public Sprite[] red;
    public Image image;
    private int count = 0;


    private Sprite[] selectedColor;

    private void Start()
    {
        selectedColor = blue;
    }

    public void Switch()
    {
        count = count >= selectedColor.Length - 1 ? 0 : count + 1;
        image.sprite = selectedColor[count];
    }


    public void ChangeColor(string val)
    {
        count = 0;
        switch (val)
        {
            case "blue":
                selectedColor = blue;
                break;
            case "green":
                selectedColor = green;
                break;
            case "orange":
                selectedColor = orange;
                break;
            case "red":
                selectedColor = red;
                break;
        }

        image.sprite = selectedColor[count];
    }

    
}