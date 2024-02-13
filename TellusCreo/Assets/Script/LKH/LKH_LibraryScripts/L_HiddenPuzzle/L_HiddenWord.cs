using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_HiddenWord : MonoBehaviour
{
    //[SerializeField] private L_HiddenPuzzle puzzle;
    private SpriteRenderer spr;

    static private Color n = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    static private Color s = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    static private Color a = new Color(1.0f, 1.0f, 1.0f, 1.0f);


    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spr.color = n;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Candle")) return;

        Debug.Log("Candle trigger enter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Candle")) return;

        float dir = Vector2.Distance(L_Candle.Instance.fireCollider.transform.position, transform.position);
        if (dir < 0.5f)
            spr.color = a;
        else
            spr.color = s;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spr.color = n;
    }
}
