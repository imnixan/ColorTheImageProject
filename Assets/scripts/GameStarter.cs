using DanielLochner.Assets.SimpleZoom;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    private ImagePrefab[] prefabs;

    [SerializeField]
    private MultiTouchScrollRect msr;

    [SerializeField]
    private Transform viewport;

    private Pallete pallete;

    [SerializeField]
    private TextMeshProUGUI coloredCountText;

    private int zoneFills;
    private int totalZones;

    private void Start()
    {
        int image = PlayerPrefs.GetInt("Image");
        pallete = FindAnyObjectByType<Pallete>();

        ImagePrefab paintImage = Instantiate(prefabs[image], viewport);
        msr.content = paintImage.GetComponent<RectTransform>();
        pallete.Init(paintImage);
        totalZones = GetComponentsInChildren<FillZone>().Length;
        coloredCountText.text = $"{zoneFills}/{totalZones}";
        FillZone.zoneFilled += UpdateCounter;
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("PaintMenu");
    }

    private void UpdateCounter()
    {
        zoneFills++;
        coloredCountText.text = $"{zoneFills}/{totalZones}";
    }

    private void OnDisable()
    {
        FillZone.zoneFilled -= UpdateCounter;
    }
}
