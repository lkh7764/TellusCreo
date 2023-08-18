using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleInfo: MonoBehaviour
{
    public GameObject puzzleObj;
    public GameObject puzzleClear;

    public GameObject puzzleWindow;

    private bool isActive;
    private bool isClear;
    private bool hasClear = false;

    // 놀이방 조건
    private bool isDollPuzzle = false;
    private GameObject dollClear;

    // 서재방 조건
    private bool isLaptop;

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

        if (puzzleObj.name == "DollPuzzle")
        {
            isDollPuzzle = true;
            dollClear = GameObject.Find("DollClear");
        }

        if (gameObject.name == "laptop_object")
            isLaptop = true;
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

        if (isDollPuzzle == true)
        {
            isClear = false;
            hasClear = true;
            puzzleClear = dollClear;
        }
    }

    public bool Get_IsClear() { return isClear; }
}
