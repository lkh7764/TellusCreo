﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Camera : MonoBehaviour
{
    public GameObject nonPuzzleCanvas;
    public GameObject puzzleCanvas;

    private float sidePos_x;

    public float puzzlePos_x = -30f;
    public float puzzlePos_y = 20f;
    private Vector3 puzzlePos;

    public P_PuzzleInfo nowPuzzle;

    private void Start()
    {
        sidePos_x = -30f;
        transform.position = new Vector3(sidePos_x, 0f, -10f);

        puzzlePos = new Vector3(puzzlePos_x, puzzlePos_y, -10f);

        nowPuzzle = null;

        nonPuzzleCanvas.SetActive(true);
        puzzleCanvas.SetActive(false);
    }

    public void MoveSide(int direction)
    {
        switch (direction)
        {
            case 0:
                // move left
                sidePos_x -= 20f;
                if (sidePos_x < -30f)
                    sidePos_x = 30f;
                break;
            case 1:
                // move right
                sidePos_x += 20f;
                if (sidePos_x > 30f)
                    sidePos_x = -30f;
                break;
        }

        transform.position = new Vector3(sidePos_x, 0f, -10f);
    }

    public void PlayPuzzle(P_PuzzleInfo clickPuzzle)
    {
        if (nowPuzzle == null)
        {
            transform.position = puzzlePos;
            nowPuzzle = clickPuzzle;
            nowPuzzle.IsActive_true();
        }

        nonPuzzleCanvas.SetActive(false);
        puzzleCanvas.SetActive(true);
    }

    public void ExitPuzzle()
    {
        if (nowPuzzle != null)
        {
            transform.position = new Vector3(sidePos_x, 0f, -10f);
            nowPuzzle.IsActive_false();
            nowPuzzle = null;
        }

        nonPuzzleCanvas.SetActive(true);
        puzzleCanvas.SetActive(false);
    }
}