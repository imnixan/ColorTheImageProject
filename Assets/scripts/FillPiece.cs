using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FillPiece : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = Color.white;
    }

    public void Fill(Color color)
    {
        image.DOColor(new Color(0, 0, 0, 0), 0.5f);
    }
}
