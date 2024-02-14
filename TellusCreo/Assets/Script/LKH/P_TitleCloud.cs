using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TitleCloud : MonoBehaviour
{
    public float startY;

    public float startPos;
    public float lastPos;

    private float time;
    public float interval = 5.0f;

    public int dir;

    private void Awake()
    {
        transform.position = new Vector3(startPos, startY, 0.0f);
        time = 0.0f;
    }

    private void Update()
    {
        time += Time.deltaTime;
        float ratio = time / interval;
        float d = startPos - lastPos;

        transform.Translate(ratio * dir * d, 0.0f, 0.0f);

        if (dir == -1)
        {
            if (this.transform.position.x <= lastPos)
                dir = 1;
        }
        else
        {
            if (this.transform.position.x >= startPos)
                dir = -1;
        }

        time = 0;
    }
}
