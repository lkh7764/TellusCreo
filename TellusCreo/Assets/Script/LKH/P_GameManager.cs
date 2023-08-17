﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P_GameManager : MonoBehaviour
{
    public static P_GameManager instance;

    public bool isDown;
    public bool isUp;
    public bool isUp_nonCollider;
    public RaycastHit2D downHit;
    public RaycastHit2D upHit;

    private bool isGetKeyA;
    private bool isGetKeyB;
    private bool wireConnect;
    private bool dollClear;
    private bool topClear;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        isDown = false;
        isUp = false;
        isUp_nonCollider = false;

        isGetKeyA = false;
        isGetKeyB = false;
        wireConnect = false;
        dollClear = false;
        topClear = false;
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            ShootRay();
    }

    private void ShootRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 downPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D downRay = new Ray2D(downPos, Vector2.zero);
                downHit = Physics2D.Raycast(downRay.origin, downRay.direction, 1 << 30);

                if(downHit.collider != null)
                    isDown = true;
            }
        }
        else { isDown = false; }

        if (Input.GetMouseButtonUp(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 upPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D upRay = new Ray2D(upPos, Vector2.zero);
                upHit = Physics2D.Raycast(upRay.origin, upRay.direction);

                if (upHit.collider != null)
                {
                    isUp = true;
                    isUp_nonCollider = false;
                }
                else
                {
                    isUp = false;
                    isUp_nonCollider = true;
                }
            }
        }
        else
        {
            isUp = false;
            isUp_nonCollider = false;
        }
    }

    public void Set_isGetKeyA() 
    {
        isGetKeyA = true;
        Debug.Log("get keyA");
    }

    public bool Get_isGetKeyA() { return isGetKeyA; }

    public void Set_isGetKeyB()
    {
        isGetKeyB = true;
        Debug.Log("get keyB");
    }

    public bool Get_isGetKeyB() { return isGetKeyB; }

    public void Set_wireConnect()
    {
        wireConnect = true;
        Debug.Log("connect wire");
    }

    public bool Get_wireConnect() { return wireConnect; }

    public void Set_dollClear() 
    { 
        dollClear = true;
        Debug.Log("clear doll puzzle");
    }

    public bool Get_dollClear() { return dollClear; }

    public void Set_topClear() 
    { 
        topClear = true;
        Debug.Log("clear top puzzle");
    }

    public bool Get_topClear() { return topClear; }
}
