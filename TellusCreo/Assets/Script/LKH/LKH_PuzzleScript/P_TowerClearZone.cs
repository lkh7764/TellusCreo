using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TowerClearZone : MonoBehaviour
{
    public bool isRight;
    private bool isContect;
    private bool isColliderMove;
    private GameObject contectObj;

    private float time;
    private Vector3 colliderLastPos;

    private P_PuzzleClear clearCondition;

    private void Awake()
    {
        clearCondition = transform.GetComponentInParent<P_PuzzleClear>();
    }

    private void Start()
    {
        isRight = false;
        isContect = false;
        //isColliderMove = false;

        time = 0;

        this.gameObject.layer = 30;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isContect == false)
        {
            colliderLastPos = collision.gameObject.transform.localPosition;
            isContect = true;
            contectObj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isContect = false;
        contectObj = null;
        isColliderMove = false;

        time = 0;
    }

    private void Update()
    {
        if (!isRight && isColliderMove && contectObj.CompareTag("P_building") && time > 1.5f)
        {
            if(colliderLastPos == contectObj.transform.position)
            {
                isRight = true;
                clearCondition.CheckClear_TowerPuzzle();
            }
            else
            {
                colliderLastPos = contectObj.transform.position;
                time = 0;
            }
        }
    }

    private void LateUpdate()
    {
        if (isContect)
        {
            isColliderMove = true;
            time += Time.deltaTime;
        }
    }

    private void CheckPosition(Collider2D obj)
    {
        if (colliderLastPos != obj.transform.localPosition)
        {
            isColliderMove = true;
            colliderLastPos = obj.transform.localPosition;
        }
        else { isColliderMove = false; }
    }
}
