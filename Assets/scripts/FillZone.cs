using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class FillZone : MonoBehaviour
{
    public static event UnityAction zoneFilled;

    public bool filledCorrect;

    private TextMeshProUGUI zoneNumber;

    private FillPiece[] pieces;

    private Pallete pallete;

    public Layer layer;

    [SerializeField]
    private AudioClip fillSound,
        wrongColorSound;

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
                zoneFilled?.Invoke();
                zoneNumber.DOColor(new Color(0, 0, 0, 0), 0.5f).Play();
                if (PlayerPrefs.GetInt("Sound", 1) == 1)
                {
                    AudioSource.PlayClipAtPoint(fillSound, Vector2.zero);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Sound", 1) == 1)
                {
                    AudioSource.PlayClipAtPoint(wrongColorSound, Vector2.zero);
                }
            }

            foreach (var piece in pieces)
            {
                piece.Fill(pallete.currentColor);
            }
        }
    }
}
