﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_UI : MonoBehaviour
{
    private P_Camera cameraController;

    private void Awake()
    {
        cameraController = FindObjectOfType<P_Camera>();
    }

    public void ClickLeftArrow() { cameraController.MoveSide(0); }

    public void ClickRightArrow() { cameraController.MoveSide(1); }

    public void ClickBackArrow() { cameraController.ExitPuzzle(); }
}
