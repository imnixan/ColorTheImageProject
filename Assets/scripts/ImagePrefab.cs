using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static UnityEditor.Experimental.GraphView.GraphView;
using DanielLochner.Assets.SimpleZoom;

public class ImagePrefab : MonoBehaviour
{
    public Color[] palleteColor;
    private Layer[] layers;

    [SerializeField]
    private Image finalImage;

    [SerializeField]
    private AudioClip finishSound;

    private Window window;

    private void Start()
    {
        window = FindAnyObjectByType<Window>();
        layers = GetComponentsInChildren<Layer>();
    }

    public void LayerFinished()
    {
        foreach (var layer in layers)
        {
            if (!layer.filledCorrect)
            {
                return;
            }
        }
        FindAnyObjectByType<MultiTouchScrollRect>().enabled = false;
        FindAnyObjectByType<SimpleZoom>().enabled = false;
        Debug.Log("FINISHED");
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            AudioSource.PlayClipAtPoint(finishSound, Vector2.zero);
        }
        Sequence seq = DOTween.Sequence();
        seq.Append(finalImage.DOColor(Color.white, 0.5f))
            .AppendInterval(1)
            .AppendCallback(() =>
            {
                window.ShowEnd(finalImage.sprite);
            });
        seq.Restart();
    }
}
