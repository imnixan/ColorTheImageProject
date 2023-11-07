using DanielLochner.Assets.SimpleZoom;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    private ImagePrefab[] prefabs;

    [SerializeField]
    private MultiTouchScrollRect msr;

    [SerializeField]
    private Transform viewport;

    private Pallete pallete;

    private void Start()
    {
        int image = PlayerPrefs.GetInt("Image");
        pallete = FindAnyObjectByType<Pallete>();

        ImagePrefab paintImage = Instantiate(prefabs[image], viewport);
        msr.content = paintImage.GetComponent<RectTransform>();
        pallete.Init(paintImage);
    }
}
