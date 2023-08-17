using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_IsRightPos : MonoBehaviour
{
    public GameObject correctObj;

    public bool isTrigger;
    public bool isRight;

    private P_PuzzleClear clearCondition;

    private void Awake()
    {
        clearCondition = transform.GetComponentInParent<P_PuzzleClear>();
    }

    private void OnEnable()
    {
        isRight = false;
        gameObject.layer = 30;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTrigger = true;

        if (System.Object.ReferenceEquals(collision.gameObject, correctObj))
            isRight = true;
        else
            isRight = false;

        clearCondition.CheckClear();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         isTrigger = false;

        if (System.Object.ReferenceEquals(collision.gameObject, correctObj))
            isRight = false;
    }

    public void setIsRight()
    {
        isRight = true;
        clearCondition.CheckClear();
    }

    public void IsRight_false()
    {
        isRight = false;
    }
}
