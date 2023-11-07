using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FillZone : MonoBehaviour
{
    public bool filledCorrect;

    private TextMeshProUGUI zoneNumber;

    private FillPiece[] pieces;

    private Pallete pallete;

    public Layer layer;

    private void Start() { }

    public void Init(Layer layer)
    {
        this.layer = layer;
        pieces = GetComponentsInChildren<FillPiece>();
        pallete = FindAnyObjectByType<Pallete>();
        zoneNumber = GetComponentInChildren<TextMeshProUGUI>();
        zoneNumber.text = layer.number.ToString();
    }

    public void OnPieceClick()
    {
        if (!filledCorrect)
        {
            if (pallete.currentColor == layer.zoneColor)
            {
                filledCorrect = true;
                layer.ZoneColored();
                zoneNumber.DOColor(new Color(0, 0, 0, 0), 0.5f).Play();
            }

            foreach (var piece in pieces)
            {
                piece.Fill(pallete.currentColor);
            }
        }
    }
}
