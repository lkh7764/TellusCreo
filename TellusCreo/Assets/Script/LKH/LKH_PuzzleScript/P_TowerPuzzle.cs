using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TowerPuzzle : MonoBehaviour
{
    // 움직이는 도중에는 클릭해서 선택하지 못하도록 > P_move가 되는 조건을 살짝 수정
    private Vector2 beforePos;
    public GameObject standard;
    private float standard_x;
    private float standard_y;

    private Vector3 originPos;
    private P_Camera cameraController;

    private void Awake()
    {
        originPos = transform.position;
        cameraController = FindObjectOfType<P_Camera>();
    }

    private void OnEnable()
    {
        if (cameraController.nowPuzzle.Get_IsClear() == true)
            return;

        transform.position = originPos;
    }

    void Start()
    {
        standard_x = standard.transform.position.x;
        standard_y = standard.transform.position.y;
    }

    void Update()
    {
        if (this.CompareTag("P_stop"))
        {
            if (this.transform.position.y < standard_y - 6 || this.transform.position.x < standard_x - 10 || this.transform.position.x > standard_x + 10)
            {
                this.transform.position = beforePos;
            }
        }
    }

    private void OnMouseDown()
    {
        this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    private void OnMouseDrag()
    {
        this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "platform" && collision.contacts[0].normal.y >= 1f  && this.gameObject.CompareTag("P_building") == false)
        {
            beforePos = this.transform.position;
            this.tag = "P_building";
        }
        if (collision.gameObject.CompareTag("P_building") && this.gameObject.CompareTag("P_building") == false)
        {
            this.tag = "P_building";
        }
    }
}
