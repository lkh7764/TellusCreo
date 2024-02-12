using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_PlantGrow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] sprs;
    [SerializeField] private SpriteRenderer keyRenderer;
    [SerializeField] private Collider2D keyCollider;

    private bool growing;
    private float time;
    public float standardTime = 3.0f;
    private int step;

    private float alpha1;
    private float alpha2;

    private void Awake()
    {
        for (int i = 0; i < sprs.Length; i++)
            sprs[i].color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        keyRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        keyCollider.enabled = false;

        growing = false;
        time = 0f;
        step = 0;

        alpha1 = 0.0f;
        alpha2 = 1.0f;
    }

    private void Update()
    {
        if (!growing) return;
        time += Time.deltaTime;

        Step();
    }

    public void StartGrowing()
    {
        growing = true;
    }

    private void Step()
    {
        float alpha = Time.deltaTime / 3.0f;
        switch (step)
        {
            case 0:
                alpha1 += alpha;
                sprs[0].color = new Color(1.0f, 1.0f, 1.0f, alpha1);
                if (time >= standardTime)
                    ResetTime();
                break;
            case 1:
                alpha1 += alpha;     alpha2 -= alpha;
                sprs[0].color = new Color(1.0f, 1.0f, 1.0f, alpha2);
                sprs[1].color = new Color(1.0f, 1.0f, 1.0f, alpha1);
                if (time >= standardTime)
                    ResetTime();
                break;
            case 2:
                alpha1 += alpha; alpha2 -= alpha;
                sprs[1].color = new Color(1.0f, 1.0f, 1.0f, alpha2);
                sprs[2].color = new Color(1.0f, 1.0f, 1.0f, alpha1);
                keyRenderer.color = new Color(1.0f, 1.0f, 1.0f, alpha1);
                if (time >= standardTime)
                    ShowKey();
                break;
        }
    }

    private void ResetTime()
    {
        time = 0f;
        ++step;

        alpha1 = 0.0f;
        alpha2 = 1.0f;
    }

    private void ShowKey()
    {
        sprs[0].color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        sprs[1].color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        sprs[2].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        keyRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        keyCollider.enabled = true;
        growing = false;
    }
}
