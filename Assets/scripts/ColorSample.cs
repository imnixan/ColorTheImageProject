using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class ColorSample : MonoBehaviour, IPointerClickHandler
{
    private Pallete pallete;
    private Color sampleColor;

    public int number;

    [SerializeField]
    private Image brushColor;
    private RectTransform rt;

    public void Init(Color color, Pallete pallete)
    {
        brushColor.color = color;
        this.sampleColor = color;
        this.pallete = pallete;
        rt = GetComponent<RectTransform>();
    }

    public void ChooseAsCurrent()
    {
        if (rt.anchoredPosition.y < 0)
        {
            rt.DOAnchorPosY(0, 0.5f).Play();
        }
    }

    public void UnChoose()
    {
        if (rt.anchoredPosition.y == 0)
        {
            rt.DOAnchorPosY(-50, 0.5f).Play();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        pallete.SetCurrentColor(sampleColor, number);
    }
}
