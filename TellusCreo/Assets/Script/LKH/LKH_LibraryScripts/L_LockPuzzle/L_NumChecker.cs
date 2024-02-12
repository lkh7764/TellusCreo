using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_NumChecker : MonoBehaviour
{
    private Vector3 pos;
    private bool clicked;

    [SerializeField] private int slotNum;


    private void Awake()
    {
        pos = this.transform.position;
    }

    private void OnEnable()
    {
        clicked = false;

        Check_rightNum();
    }

    private void OnMouseDown()
    {
        Debug.Log(slotNum.ToString()+"clicked");
        clicked = true;
    }

    private void OnMouseUp()
    {
        if (!clicked) return;

        Debug.Log(slotNum.ToString() + "up");
        Check_rightNum();
    }

    private void Check_rightNum()
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(pos);
        foreach (Collider2D collider in colliders)
        {
            if (!collider.CompareTag("L_select")) continue;

            L_LockPuzzle.Instance.Set_rightNum(slotNum, true);
            clicked = false;
            return;
        }

        L_LockPuzzle.Instance.Set_rightNum(slotNum, false);
        clicked = false;
    }
}
