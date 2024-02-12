using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_WaterCup : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    private bool start;
    private float time;
    [SerializeField] private float standardTime = 3.0f;

    private void Awake()
    {
        this.tag = null;
        start = false;
        spr.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    private void OnEnable()
    {
        if (!L_GameManager.instance.isRainy())
            return;
        start = true;
    }

    private void Update()
    {
        if (!start) return;
        time += Time.deltaTime;

        float alpha = time / 3.0f;
        spr.color = new Color(1.0f, 1.0f, 1.0f, alpha);

        if (time >= standardTime)
            FillCup();
    }

    private void FillCup()
    {
        Debug.Log("WaterCup ready");
        start = false;
        spr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        this.tag = "P_item";

        Destroy(this);
    }
}
