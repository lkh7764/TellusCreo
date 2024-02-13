using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class L_LockSlot : MonoBehaviour
{
    [SerializeField] private Transform numbers;
    private Vector3 originPos;

    private bool clicked;
    private bool rightPos;

    private Vector2 dragStartPosition;


    private void Awake()
    {
        originPos = numbers.position;
    }

    private void OnEnable()
    {
        numbers.position = originPos;

        clicked = false;
        rightPos = false;
    }

    private void OnMouseDown()
    {
        //L_GameManager instance = L_GameManager.instance;
        //if (!System.Object.ReferenceEquals
        //    (instance.downHit.collider.gameObject, this.gameObject)) return;

        clicked = true;
        dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(dragStartPosition);
    }

    private void OnMouseDrag()
    {
        if (!clicked) return;

        Vector2 thisPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float y = thisPos.y - dragStartPosition.y;
        numbers.transform.Translate(new Vector3(0.0f, 0.05f*y, 0.0f));
    }

    public void ResetNumberPos(Vector3 pos)
    {
        numbers.position = pos;
    }

    public void Set_isRightPos(bool value = true) { rightPos = value; }
    public bool IsRightPos() { return rightPos; }
}
