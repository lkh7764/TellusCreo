using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_WeatherController : MonoBehaviour
{
    [SerializeField] private Sprite[] weatherImg;
    [SerializeField] private SpriteRenderer weatherRenderer;
    [SerializeField] private bool rainy;
    private bool selected;
    private bool clicked;

    private SpriteRenderer spr;
    private Color[] colors;

    [SerializeField] private L_WeatherController other;


    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();

        colors = new Color[2];
        colors[0] = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        colors[1] = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        spr.color = colors[0];

        if (rainy)
        {
            spr.sprite = weatherImg[0];
            selected = false;
        }
        else
        {
            spr.sprite = weatherImg[1];
            weatherRenderer.sprite = weatherImg[2];
            selected = true;
        }
    }

    private void OnEnable()
    {
        clicked = false;
    }

    private void OnMouseDown()
    {
        spr.color = colors[1];

        if (selected) return;
        clicked = true;
    }

    private void OnMouseUp()
    {
        if (!clicked) return;
        spr.color = colors[0];

        L_GameManager.instance.Set_rainy(rainy);
        weatherRenderer.sprite = weatherImg[2];
        spr.sprite = weatherImg[1];
        other.Set_selectedFalse();

        SoundManager.Instance.Play("mouse-click-153941");
    }

    public void Set_selectedFalse()
    {
        selected = false;
        spr.sprite = weatherImg[0];
    }
}
