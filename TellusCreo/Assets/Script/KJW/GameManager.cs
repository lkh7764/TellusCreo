﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{

    static GameManager s_instance = null;

    public static GameManager Instance { get { if (s_instance == null) return null; return s_instance; } }


    public enum Puzzle
    {
        Poster = 10,
        WetTissue,
        Star,
        SignatureCard, // 13
        Wire,
        ShadowLight, // 15
        ArcadeConsole,
        Lock,
        LightSwitch,
        ChangeView,
        Curtain,
    }

    Action Room;
    public UI Ui;
    public GameObject[] Puzzles;
    public bool onPuzzle;
    bool[] ClearPuzzles;
    bool isCurtainOpen;

    public bool this[int idx] // 인덱서 사용
    {
        get => ClearPuzzles[idx];
        set
        {
            ClearPuzzles[idx] = value;
            Room?.Invoke(); // Room이 null이 아닐때만
        }
    }

    [SerializeField]
    GameObject light2D;
    [SerializeField]
    GameObject globalLight;
    Light2D globalLight2D;

    void Start()
    {
        Room += CheckRoomClear;
        ClearPuzzles = new bool[10];
        isCurtainOpen = false;
        s_instance = this;
        onPuzzle = false;
        globalLight2D = globalLight?.GetComponent<Light2D>();
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            HandlePuzzleClick();
        }
    }

    void HandlePuzzleClick()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 바꾸기
        RaycastHit2D rayHit = Physics2D.Raycast(mousePos, transform.forward, 10f); // 레이캐스트
        if (rayHit.collider == null)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject hitGameObject = rayHit.collider.gameObject;

            switch ((Puzzle)((int)hitGameObject.layer))
            {
                case Puzzle.LightSwitch:
                    if (ClearPuzzles[(int)Puzzle.LightSwitch - 10])
                        globalLight2D.intensity = globalLight2D.intensity == 0.5f ? 1f : 0.5f;
                    else // 테스트용
                        Debug.Log("전선 연결 필요");
                    break;

                case Puzzle.ChangeView:
                    Puzzles[(int)Puzzle.Star - 10]?.GetComponent<BackgroundManager>()?.ChangeBackgroundSprite(); // 창밖변환
                    Debug.Log("창밖 변환");
                    break;

                case Puzzle.Curtain:
                    Debug.Log("커튼 상태 " + (isCurtainOpen = !isCurtainOpen));
                    if(hitGameObject.transform.childCount!=0)
                    {
                        hitGameObject.transform.GetChild(0).gameObject.SetActive(true); // 전선 타일 
                    }
                    if (hitGameObject.CompareTag("Background2"))
                    {
                        hitGameObject.transform.parent.GetComponent<BackgroundManager>()?.ChangeBackgroundSprite();
                    }
                    break;
                case Puzzle.Lock:
                    Debug.Log("LockPuzzle");
                    Puzzles[(int)Puzzle.Lock - 10].SetActive(true);
                    ChangeBackground();
                    break;
                case Puzzle.ArcadeConsole:
                    if (ClearPuzzles[(int)Puzzle.LightSwitch - 10])
                    {
                        Puzzles[(int)Puzzle.ArcadeConsole - 10].SetActive(true);
                        ChangeBackground();
                    }
                    else
                    {
                        Debug.Log("전선 연결 필요");
                        break;
                    }
                    Debug.Log("ArcadeConsole");
                    break;

                case Puzzle.Poster:
                   
                    if (hitGameObject.CompareTag("PosterCorners")) // 포스터의 모서리라면
                    {
                        Debug.Log("PosterCorners");
                        BackgroundManager background = hitGameObject.transform.parent.parent.GetComponent<BackgroundManager>();
                        background?.ChangeBackgroundSprite();
                        background?.transform.GetChild(1).gameObject.SetActive(true); // AfterPoster
                        background?.transform.GetChild(0).gameObject.SetActive(false); // BeforePoster
                    }
                    else if(hitGameObject.CompareTag("AfterPoster"))
                    {
                        BackgroundManager background = hitGameObject.transform.parent.GetComponent<BackgroundManager>();
                        background?.ChangeBackgroundSprite();
                        hitGameObject.transform.gameObject.SetActive(false); // AfterPoster
                        background?.transform.GetChild(0).gameObject.SetActive(true); // BeforePoster
                    }
                    else
                    {
                        Debug.Log("Poster");
                        Puzzles[(int)Puzzle.Poster - 10].SetActive(true);
                        ChangeBackground();
                    }
                    break;

                case Puzzle.WetTissue:
                    Puzzles[(int)Puzzle.WetTissue - 10].SetActive(true);
                    Debug.Log("WetTissue");
                    ChangeBackground();
                    break;

                case Puzzle.SignatureCard:
                    Puzzles[(int)Puzzle.SignatureCard - 10].SetActive(true);
                    Debug.Log("SignatureCard");
                    ChangeBackground();
                    break;

                case Puzzle.Star:
                    Puzzles[(int)Puzzle.Star - 10].SetActive(true);
                    ToggleLights();
                    Debug.Log("Star");
                    ChangeBackground();
                    break;

                case Puzzle.Wire:
                    Puzzles[(int)Puzzle.Wire - 10].SetActive(true);
                    Debug.Log("Wire");
                    ChangeBackground();
                    break;

                case Puzzle.ShadowLight:
                    Puzzles[(int)Puzzle.ShadowLight - 10].SetActive(true);
                    Debug.Log("ShadowLight");
                    ChangeBackground();
                    break;
            }
        }
    }

    public void ToggleLights()
    {
        // 라이트가 켜져있으면 끄고, 꺼져있으면 켠다
        light2D.gameObject.SetActive(!light2D.gameObject.activeSelf);
        globalLight.gameObject.SetActive(!globalLight.gameObject.activeSelf);

        if (light2D.gameObject.activeSelf)
        {
            float lightY = -25f; // light2D의 y 좌표 값
            light2D.transform.position = new Vector2(0, lightY);
        }
    }

    void ChangeBackground()// 뒷 배경 퍼즐 배경으로 변경
    {
        if (!onPuzzle)
        {
            Ui.prevCameraPos = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(0, -25f, -100f);
            ActiveBackArrow();
            onPuzzle = true;
        }
    } 

    void ActiveBackArrow()
    {
        Ui.backArrow.SetActive(true);
        Ui.DisableArrow();

    }

    void CheckRoomClear()
    {

        foreach (var puzzle in ClearPuzzles)
        {
            if (!puzzle)
            {
                Debug.Log("풀 퍼즐이 남았음");
                return;
            }
        }

    }

}
