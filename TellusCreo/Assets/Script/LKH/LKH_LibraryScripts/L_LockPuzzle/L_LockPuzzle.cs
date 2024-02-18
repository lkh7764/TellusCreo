using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_LockPuzzle : MonoBehaviour
{
    public static L_LockPuzzle Instance;

    public P_PuzzleInfo info;
    private bool[] rightNum;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        rightNum = new bool[4];
        for (int i = 0; i < 4; i++)
            rightNum[i] = false;
    }

    private void Check_lockClear()
    {
        foreach(bool r in rightNum)
        {
            if (r == false)
                return;
        }

        info.IsClear_true();
        SoundManager.Instance.Play("puzzle_clear");
    }

    public void Set_rightNum(int num, bool value)
    {
        rightNum[num] = value;
        Debug.Log("slot " + num.ToString() + " " + value.ToString());
        Check_lockClear();
    }
}
