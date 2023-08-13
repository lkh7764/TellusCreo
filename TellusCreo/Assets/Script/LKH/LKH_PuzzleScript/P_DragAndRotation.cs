using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DragAndRotation : MonoBehaviour
{
    private float angle;
    private Vector2 clockHand, mouse;

    private Quaternion originAngle;
    private P_Camera cameraController;

    private SpriteRenderer objectRenderer;
    private int layer_S;
    private int layer_NS;

    private void Awake()
    {
        originAngle = transform.rotation;
        cameraController = FindObjectOfType<P_Camera>();
        
        objectRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        if (cameraController.nowPuzzle.Get_IsClear() == true)
            return;

        transform.rotation = originAngle;
    }

    private void Start()
    {
        this.tag = "P_stop";
        layer_S = SortingLayer.NameToID("P_Select");
        layer_NS = SortingLayer.NameToID("P_NotSelect");
        ChangeLayer(30);

        if (P_GameManager.instance.Get_dollClear() == false)
            this.transform.GetComponentInChildren<Collider2D>().enabled = false;
    }

    private void ChangeLayer(int layerNum)
    {
        if (layerNum == 30)
        {
            this.gameObject.layer = 30;
            objectRenderer.sortingLayerID = layer_NS;
        }
        else if (layerNum == 31)
        {
            this.gameObject.layer = 31;
            objectRenderer.sortingLayerID = layer_S;
        }
    }

    private void OnMouseDrag()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - clockHand.y, mouse.x - clockHand.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (P_GameManager.instance.isDown == true)
        {
            RaycastHit2D downHit = P_GameManager.instance.downHit;
            if (System.Object.ReferenceEquals(gameObject, downHit.collider.gameObject))
            {
                this.tag = "P_move";
                clockHand = transform.position;
                ChangeLayer(31);
            }
        }

        if (P_GameManager.instance.isUp == true)
        {
            RaycastHit2D upHit = P_GameManager.instance.upHit;
            if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
            {
                this.tag = "P_stop";
                ChangeLayer(30);
            }
        }
    }
}
