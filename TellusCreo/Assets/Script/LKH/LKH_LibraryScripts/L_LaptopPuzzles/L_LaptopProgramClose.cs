using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_LaptopProgramClose : MonoBehaviour
{
    [SerializeField] private GameObject program;
    private bool clicked;

    private SpriteRenderer spr;
    private Color[] colors;


    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();

        colors = new Color[2];

        colors[0] = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        colors[1] = new Color(0.5f, 0.5f, 0.5f, 1.0f);

        spr.color = colors[0];
    }

    private void OnEnable()
    {
        clicked = false;
    }


    private void OnMouseDown()
    {
        clicked = true;
        spr.color = colors[1];
    }


    private void OnMouseUp()
    {
        if (!clicked) return;

        SoundManager.Instance.Play("mouse-click-153941");

        L_LaptopPrograms.programRunning = false;
        clicked = false;
        spr.color = colors[0];
        program.SetActive(false);
    }
}
