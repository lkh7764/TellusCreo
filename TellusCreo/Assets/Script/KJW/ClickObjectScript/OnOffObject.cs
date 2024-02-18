﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffObject : ClickObject
{
    private bool _isOnObject;

    override protected void Start()
    {
        _isOnObject = false;
    }
    void OnMouseDown()
    {
        if (activeObject != null)
        {
            SoundManager.Instance.Play("open_lockedDoor");
            activeObject.SetActive((_isOnObject = !_isOnObject));
        }
    }
}
