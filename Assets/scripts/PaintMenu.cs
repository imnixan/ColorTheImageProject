using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintMenu : MonoBehaviour
{
    public void Start()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void PaintTiger()
    {
        SceneManager.LoadScene("PaintScene");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
