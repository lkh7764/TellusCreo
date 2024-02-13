using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Window : MonoBehaviour
{
    [SerializeField] private Sprite[] weatherImgs;
    private SpriteRenderer spr;


    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();

        this.tag = null;
        spr.sprite = weatherImgs[0];
    }

    private void OnEnable()
    {
        bool rainy = L_GameManager.instance.isRainy();
        if (rainy)
        {
            this.tag = "Cup";
            spr.sprite = weatherImgs[1];
            return;
        }
        this.tag = null;
        spr.sprite = weatherImgs[0];
    }
}
