using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Layer : MonoBehaviour
{
    private FillZone[] fillZones;

    public int number;

    public Color zoneColor;

    public bool filledCorrect;

    [SerializeField]
    private Image contour;

    private ImagePrefab baseImage;

    private void Start()
    {
        baseImage = GetComponentInParent<ImagePrefab>();
        fillZones = GetComponentsInChildren<FillZone>();
        foreach (var zone in fillZones)
        {
            zone.Init(this);
        }
    }

    public void ZoneColored()
    {
        foreach (var zone in fillZones)
        {
            if (!zone.filledCorrect)
            {
                filledCorrect = false;
                return;
            }
        }
        filledCorrect = true;
        contour.DOColor(new Color(0, 0, 0, 0), 0.5f).Play();
        baseImage.LayerFinished();
    }
}
