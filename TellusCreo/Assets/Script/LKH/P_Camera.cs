﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Camera : MonoBehaviour
{
    public static P_Camera instance;

    // 카메라 이동 및 UI 설정하는 스크립트
    [SerializeField] private GameObject nonPuzzleCanvas;
    [SerializeField] private GameObject puzzleCanvas;

    [SerializeField] private float sidePos_x = -30f;

    [SerializeField] private float puzzlePos_x = -30f;
    [SerializeField] private float puzzlePos_y = 20f;

    public P_PuzzleInfo nowPuzzle;

    public bool isPlayPuzzle;
    private bool hint;
    private GameObject previousWindow;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        nonPuzzleCanvas.SetActive(true);
        puzzleCanvas.SetActive(false);

        //transform.position = new Vector3(sidePos_x, 0f, -10f);
        transform.SetPositionAndRotation(new Vector3(sidePos_x, 0f, -10f), Quaternion.identity);

        nowPuzzle = null;

        isPlayPuzzle = false;
        hint = false;
        previousWindow = null;
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

        // transform.position = new Vector3(sidePos_x, 0f, -10f);
        transform.SetPositionAndRotation(new Vector3(sidePos_x, 0f, -10f), Quaternion.identity);
    }

    public void PlayPuzzle(P_PuzzleInfo clickPuzzle)
    {
        if (nowPuzzle == null)
        {
            //transform.position = new Vector3(puzzlePos_x, puzzlePos_y, -10f);
            transform.SetPositionAndRotation(new Vector3(puzzlePos_x, puzzlePos_y, -10f), Quaternion.identity);
            nowPuzzle = clickPuzzle;
            nowPuzzle.IsActive_true();
        }

        nonPuzzleCanvas.SetActive(false);
        puzzleCanvas.SetActive(true);

        isPlayPuzzle = true;
    }

    public void ShowHintWindow(GameObject hintWindow)
    {
        previousWindow = nowPuzzle.puzzleWindow;
        previousWindow.SetActive(false);
        nowPuzzle.puzzleWindow = hintWindow;
        nowPuzzle.puzzleWindow.SetActive(true);

        hint = true;
    }

    private void CloseHintWindow()
    {
        nowPuzzle.puzzleWindow.SetActive(false);
        nowPuzzle.puzzleWindow = previousWindow;
        previousWindow = null;
        nowPuzzle.puzzleWindow.SetActive(true);

        hint = false;
    }

    public void ExtiPuzzle()
    {
        if (hint)
        {
            CloseHintWindow();
            return;
        }

        if (nowPuzzle != null)
        {
            //transform.position = new Vector3(sidePos_x, 0f, -10f);
            transform.SetPositionAndRotation(new Vector3(sidePos_x, 0f, -10f), Quaternion.identity);
            nowPuzzle.IsActive_false();
            nowPuzzle = null;
        }

        nonPuzzleCanvas.SetActive(true);
        puzzleCanvas.SetActive(false);

        isPlayPuzzle = false;
    }
}