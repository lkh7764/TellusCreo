﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Vector3 prevCameraPos;

    public GameObject backArrow;

    public GameObject[] lrArrow;


    public void BackArrow()
    {
        GameManager.Instance.onPuzzle = false;
        backArrow.SetActive(false);
        foreach (var arrow in lrArrow)
        {
            arrow.SetActive(true);
        }
        Camera.main.transform.position = prevCameraPos;

        if (GameManager.Instance.Puzzles[(int)(GameManager.Puzzle.Star) - GameManager.Instance.NUMBER_OF_PUZZLES].activeSelf)
        {   // 별자리 퍼즐이 켜져 있을때만
            GameManager.Instance.ToggleLights();
        }

        foreach (var puzzle in GameManager.Instance.Puzzles) // 모든 퍼즐 비활성화
        {
            puzzle.SetActive(false);
        }
    }

    public void LeftArrow()
    {
        Camera.main.transform.position = new Vector3((Camera.main.transform.position.x + 60) % 80, 0f, -10f);
    }

    public void RightArrow()
    {

        Camera.main.transform.position = new Vector3((Camera.main.transform.position.x + 20) % 80, 0f, -10f);
    }

    public void DisableArrow()
    {
        foreach (var arrow in lrArrow)
        {
            arrow.SetActive(false);
        }
      
    }

    public void ActiveBackArrow()
    {
        backArrow.SetActive(true);
        DisableArrow();
    }
}
