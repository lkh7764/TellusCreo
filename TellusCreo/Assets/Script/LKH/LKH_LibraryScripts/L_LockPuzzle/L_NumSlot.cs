using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_NumSlot : MonoBehaviour
{
    [SerializeField] private RectTransform tsf;

    private Vector3 originPos;
    private float interval = 1830f;

    [SerializeField] private float upperMax = 800f;
    [SerializeField] private float lowerMin = 3400f;


    void Awake()
    {
        originPos = tsf.localPosition;
        originPos.y = 1000f;
    }

    private void OnEnable()
    {
        tsf.localPosition = originPos;
    }

    void Update()
    {
        float y = tsf.localPosition.y;
        if (y < upperMax)
            ResetPos_upper();
        else if (y > lowerMin)
            ResetPos_lower();
    }

    void ResetPos_upper()
    {
        Vector3 thisPos = tsf.localPosition;
        thisPos.y += interval;
        tsf.localPosition = thisPos;
    }

    void ResetPos_lower()
    {
        Vector3 thisPos = tsf.localPosition;
        thisPos.y -= interval;
        tsf.localPosition = thisPos;
    }
}
