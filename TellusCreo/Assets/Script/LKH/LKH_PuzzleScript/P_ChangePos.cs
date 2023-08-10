using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P_ChangePos : MonoBehaviour
{
    private Vector2 beforePos;
    private Vector2 afterPos;

    public bool isMove = false;
    public bool isSet = true;
    private bool startOnTrig = false;
    private int checkLayer;

    private P_Camera cameraController;

    private void Awake()
    {
        cameraController = FindObjectOfType<P_Camera>();

        GetComponent<Collider2D>().isTrigger = true;
    }

    public void SetObj()
    {
        if (!isSet && !isMove)
        {
            this.transform.localPosition = beforePos;
            isSet = true;
            startOnTrig = false;
            checkLayer = 0;
        }
    }

    IEnumerator StartSet()
    {
        yield return null;
        SetObj();
    }

    private void FixedUpdate()
    {
        if (startOnTrig)
            StartCoroutine(StartSet());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSet && collision.CompareTag("P_stop"))
        {
            afterPos = collision.transform.localPosition;
            collision.transform.localPosition = beforePos;
            beforePos = afterPos;
        }
    }

    private void PlayerInput()
    {
        if (P_GameManager.instance.isDown == true)
        {
            RaycastHit2D downHit = P_GameManager.instance.downHit;
            if (System.Object.ReferenceEquals(this.gameObject, downHit.collider.gameObject))
            {
                isSet = false;
                beforePos = this.transform.localPosition;
                checkLayer = 1;
            }
        }
    }

    private void Update()
    {
        if (this.CompareTag("P_move"))
            isMove = true; 
        else 
            isMove = false;

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            PlayerInput();
        }

        if (checkLayer == 1 && !isMove)
            startOnTrig = true;
    }

    public void LateUpdate()
    {
        if (checkLayer == 2)
            startOnTrig = true;
    }
}