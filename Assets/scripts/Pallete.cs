using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pallete : MonoBehaviour
{
    public Color currentColor;

    private ColorSample[] colorsUI;

    public void SetCurrentColor(Color color, int number)
    {
        currentColor = color;

        foreach (var brush in colorsUI)
        {
            if (brush.number == number)
            {
                brush.ChooseAsCurrent();
            }
            else
            {
                brush.UnChoose();
            }
        }
    }

    public void Init(ImagePrefab image)
    {
        colorsUI = GetComponentsInChildren<ColorSample>();
        currentColor = image.palleteColor[0];
        for (int i = 0; i < image.palleteColor.Length; i++)
        {
            colorsUI[i].Init(image.palleteColor[i], this);
        }
        colorsUI[0].ChooseAsCurrent();
    }
}
