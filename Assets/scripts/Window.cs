using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Window : MonoBehaviour
{
    [SerializeField]
    private Image showImage;

    [SerializeField]
    private RectTransform topBar,
        botBar;

    public void ShowEnd(Sprite sprite)
    {
        showImage.sprite = sprite;
        topBar.DOMoveY(100, 0.5f).Play();
        botBar.DOMoveY(-100, 0.5f).Play();
        GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f).Play();
    }
}
