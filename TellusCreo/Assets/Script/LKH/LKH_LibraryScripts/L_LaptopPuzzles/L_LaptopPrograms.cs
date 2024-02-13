using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_LaptopPrograms : MonoBehaviour
{
    public static bool programRunning;
    private bool clicked;

    [SerializeField] private GameObject warningWindow;
    [SerializeField] private GameObject programWindow;

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
        programRunning = false;
        clicked = false;

        warningWindow.SetActive(false);
        programWindow.SetActive(false);
    }

    private void OnMouseDown()
    {
        spr.color = colors[1];
        clicked = true;
    }

    private void OnMouseUp()
    {
        if (!clicked) return;
        spr.color = colors[0];

        if (programRunning) return;
        GameObject obj = warningWindow;
        if (L_GameManager.instance.isOjakgyoClear())
        {
            obj = programWindow;
            SoundManager.Instance.Play("mouse-click-153941");
        }
        else
            SoundManager.Instance.Play("puzzle_Arcade_cant_use");

        ShowWindow(obj);
    }

    private void ShowWindow(GameObject obj) 
    {
        obj.SetActive(true);
        programRunning = true;
    }
}
