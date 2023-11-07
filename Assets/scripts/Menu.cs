using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI appname;

    [SerializeField]
    private Image soundIcon;

    [SerializeField]
    private Sprite[] soundState;
    private AudioSource sound;

    public void Start()
    {
        sound = GetComponent<AudioSource>();
        appname.text = Application.productName;
        SetSound();
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            sound.Play();
        }
    }

    public void GoPaintMenu()
    {
        SceneManager.LoadScene("PaintMenu");
    }

    public void ChangeSound()
    {
        PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound", 1) == 1 ? 0 : 1);
        PlayerPrefs.Save();
        SetSound();
    }

    private void SetSound()
    {
        soundIcon.sprite = soundState[PlayerPrefs.GetInt("Sound", 1)];
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            sound.Play();
        }
        else
        {
            sound.Pause();
        }
    }
}
