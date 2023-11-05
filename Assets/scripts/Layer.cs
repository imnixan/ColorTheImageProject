using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Layer : MonoBehaviour
{
    private FillZone[] fillZones;

    public int number;

    public Color zoneColor;

    public bool filledCorrect;

    private void Start()
    {
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
    }
}
