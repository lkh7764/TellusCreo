using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Candle : MonoBehaviour
{
    public static L_Candle Instance;

    private Vector3 originPos;

    public Collider2D fireCollider;
    [SerializeField] private SpriteRenderer candleSpr;
    [SerializeField] private Sprite candleImg;

    private bool candle;
    private bool clicked;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        originPos = this.transform.position;

        fireCollider.enabled = false;

        candle = false;
        clicked = false;
    }

    public void Set_candle()
    {
        fireCollider.enabled = true;
        candleSpr.sprite = candleImg;

        this.tag = "Untagged";

        candle = true;
    }

    private void OnEnable()
    {
        if (!candle) return;

        transform.position = originPos;
    }

    private void OnMouseDown()
    {
        if (!candle) return;

        transform.position = originPos;
        clicked = true;
    }

    private void OnMouseDrag()
    {
        if (!clicked) return;

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        transform.position = position;
    }

    private void OnMouseUp()
    {
        if (!clicked) return;

        transform.position = originPos;
        clicked = false;
    }
}
