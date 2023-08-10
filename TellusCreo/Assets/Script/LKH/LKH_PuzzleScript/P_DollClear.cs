using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DollClear : MonoBehaviour
{
    private bool isFirst;

    private bool startRotate;
    private float angle;

    void Start()
    {
        isFirst = true;

        startRotate = false;
        angle = 0f;
    }

    void Update()
    {
        if (isFirst == false)
            return;

        if (startRotate == false)
            return;

        if (angle >= 80f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 80f);
            startRotate = false;
            isFirst = false;
            Destroy(this);
        }
    }

    public void RotateStick() { startRotate = true; }
}
