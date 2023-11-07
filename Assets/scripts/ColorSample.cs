using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorSample : MonoBehaviour, IPointerClickHandler
{
    private Pallete pallete;
    private Color sampleColor;

    public void Init(Color color, Pallete pallete)
    {
        GetComponent<Image>().color = color;
        this.sampleColor = color;
        this.pallete = pallete;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        pallete.SetCurrentColor(sampleColor);
    }
}
