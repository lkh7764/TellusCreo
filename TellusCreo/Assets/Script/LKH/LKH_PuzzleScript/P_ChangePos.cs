﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ChangePos : MonoBehaviour
{
    private Vector2 beforePos;
    private Vector2 afterPos;

    private bool isMove;
    private bool isSet;
    private bool startOnTrig;
    private int checkLayer;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    public void SetObj()
    {
        if (!isSet && !isMove)
        {
            transform.localPosition = beforePos;
            isSet = true;
            startOnTrig = false;
            checkLayer = 0;
        }
    }

    IEnumerator StartSet()
    {
        yield return null;
        SetObj();
    }

    private void FixedUpdate()
    {
        if (startOnTrig)
            StartCoroutine(StartSet());
    }

    protected void ChangePosition(Collider2D collision)
    {
        if (!isSet && collision.CompareTag("P_stop"))
        {
            afterPos = collision.transform.localPosition;
            collision.transform.localPosition = beforePos;
            beforePos = afterPos;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        ChangePosition(collision);
    }

    private void PlayerInput()
    {
        if (P_GameManager.instance.isDown)
        {
            GameObject downHit = P_GameManager.instance.downHit.collider.gameObject;
            if (System.Object.ReferenceEquals(gameObject, downHit))
            {
                isSet = false;
                beforePos = this.transform.localPosition;
                checkLayer = 1;
            }
        }
    }

    private void Update()
    {
        if (this.CompareTag("P_move")) 
            isMove = true; 
        else
            isMove = false;

        PlayerInput();

        if (checkLayer == 1 && !isMove)
            startOnTrig = true;
    }

    public void LateUpdate()
    {
        if (checkLayer == 2)
            startOnTrig = true;
    }
}