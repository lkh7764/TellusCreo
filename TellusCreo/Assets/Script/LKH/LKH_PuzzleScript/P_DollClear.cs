using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DollClear : MonoBehaviour
{
    private bool isFirst;

    private bool startRotate;
    private float angle;

    // 비활성화 상태에서 실행되지 않음.
    void Awake()
    {
        isFirst = true;

        startRotate = false;
        angle = 0f;
    }

    private void OnEnable()
    {
        if (isFirst == true)
            startRotate = true;
    }

    void Update()
    {
        if (isFirst == false)
            return;

        if (startRotate == false)
            return;

        angle += 80 * Time.deltaTime;
        if (angle >= 80f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 80f);
            startRotate = false;
            isFirst = false;
            Destroy(this);
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void RotateStick() { startRotate = true; }
}
