﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleInfo: MonoBehaviour
{
    public GameObject puzzleObj;
    public GameObject puzzleClear;

    public GameObject puzzleWindow;

    private bool isActive;
    private bool isClear;
    private bool hasClear;

    public GameObject dollClear;

    private void Start()
    {
        puzzleObj.SetActive(false);
        puzzleWindow = puzzleObj;

        isActive = false;
        isClear = false;

        if (puzzleClear != null)
        {
            hasClear = true;
            puzzleClear.SetActive(false);
        }
        else
            hasClear = false;
    }

    public void IsActive_true()
    {
        isActive = true;
        puzzleWindow.SetActive(true);
    }

    public void IsActive_false()
    {
        isActive = false;
        puzzleWindow.SetActive(false);
    }

    public void IsClear_true()
    {
        isClear = true;
        if (hasClear == true)
        {
            puzzleWindow.SetActive(false);
            puzzleWindow = puzzleClear;
            puzzleWindow.SetActive(true);
        }

        if (dollClear != null)
        {
            isClear = false;
            hasClear = true;
            puzzleClear = dollClear;
            dollClear = null;
        }
    }

    public bool Get_IsClear() { return isClear; }
}
