using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class FillPiece : MonoBehaviour
{
    private Image image;
    private FillZone fillZone;
    private bool mouseTap;
    private Vector2 mousePos;

    private void Start()
    {
        fillZone = GetComponentInParent<FillZone>();
        image = GetComponent<Image>();

        image.color = Color.white;

        Material imageMat = new Material(image.material);
        image.material = imageMat;
        image.material.SetFloat("Vector1_E974001A", 0);
    }

    public void Fill(Color color)
    {
        image.color = color;
        StartCoroutine(FillPieceSmooth());
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && mouseTap)
        {
            mouseTap = false;
            Vector2 newMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(newMousePos, mousePos) < 0.5f)
            {
                fillZone.OnPieceClick();
            }
        }
    }

    IEnumerator FillPieceSmooth()
    {
        for (float i = 0; i < 2.5f; i += 0.01f)
        {
            image.material.SetFloat("Vector1_E974001A", i);
            yield return null;
        }
    }

    private void OnMouseDown()
    {
        mouseTap = true;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    //fillZone.OnPieceClick();
    //    Debug.Log(fillZone.layer.number.ToString() + fillZone.gameObject.name);
    //    Debug.Log("This was PointerClick");
    //}
}
