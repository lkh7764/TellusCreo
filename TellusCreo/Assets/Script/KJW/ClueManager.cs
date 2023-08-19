﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> spritesForChange;
    [SerializeField]
    private GameObject clue;
    [SerializeField]
    private bool isChild;
    private int _index;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        _index = 0;
    }

    void OnMouseDown()
    {
        ShowClue();
        if (spritesForChange.Count <= 0)
            return;
        Sprite sprite = spritesForChange[_index];
        _index = (_index + 1) % spritesForChange.Count;

        if (isChild)
        {
            transform.parent.GetComponent<BackgroundManager>().ChangeBackgroundSprite(sprite);
        }
        else
        {
            spriteRenderer.sprite = sprite;
        }
    }

    public void ShowClue()
    {
        if (clue != null)
        {
            clue.SetActive(true);
        }
    }

}
