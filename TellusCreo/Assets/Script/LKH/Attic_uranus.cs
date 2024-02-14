using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attic_uranus : MonoBehaviour
{
    public float startSize = 0.05f;
    public float lastSize = 0.15f;
    private float n;

    public float interval = 2.0f;
    private float time = 0.0f;

    private SpriteRenderer spr;
    private Collider2D col;

    public bool start;


    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void Start()
    {
        transform.localScale = new Vector3(startSize, startSize, 1.0f);
        spr.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        col.enabled = false;

        n = lastSize - startSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start) return;

        time += Time.deltaTime;
        float ratio = time / interval;
        float size = ratio*n + startSize;
        float alpha = ratio;

        transform.localScale = new Vector3(size, size, 1.0f);
        spr.color = new Color(1.0f, 1.0f, 1.0f, alpha);


        if (time >= interval)
            Finish();
    }

    public void StartShow()
    {
        start = true;
    }

    private void Finish()
    {
        start = false;

        transform.localScale = new Vector3(lastSize, lastSize, 1.0f);
        spr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        col.enabled = true;

        Destroy(this);
    }
}
