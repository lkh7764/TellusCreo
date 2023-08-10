using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PicturePuzzle : P_DragAndDrop
{
    private Vector3 originPos;
    private P_Camera cameraController;

    private float pos_x;

    protected override void Awake()
    {
        base.Awake();

        originPos = transform.position;
        cameraController = FindObjectOfType<P_Camera>();
    }

    private void OnEnable()
    {
        if (cameraController.nowPuzzle.Get_IsClear() == true)
            return;

        transform.position = originPos;
        pos_x = transform.position.x;
    }

    protected override void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector2(pos_x, objectPosition.y);
    }
}
