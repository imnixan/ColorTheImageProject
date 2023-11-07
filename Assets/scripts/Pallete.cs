using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pallete : MonoBehaviour
{
    public Color currentColor;

    private ColorSample[] colorsUI;

    [SerializeField]
    private Image palleteColor;

    public void SetCurrentColor(Color color)
    {
        currentColor = color;

        palleteColor.color = currentColor;
    }

    public void Init(ImagePrefab image)
    {
        colorsUI = GetComponentsInChildren<ColorSample>();
        currentColor = image.palleteColor[0];
        palleteColor.color = currentColor;
        for (int i = 0; i < image.palleteColor.Length; i++)
        {
            colorsUI[i].Init(image.palleteColor[i], this);
        }
    }
}
