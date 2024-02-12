using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_BookPuzzle : MonoBehaviour
{
    private Vector3 originPos;
    private float pos_y;

    private Collider2D col;

    public GameObject movingBook;
    private GameObject move;

    [SerializeField] private bool addedBook;

    [SerializeField] private Sprite rightSpr;
    public SpriteRenderer spr;
    private Sprite originSpr;
    private bool rightPos;


    public void ResetPuzzle()
    {
        col.enabled = true;
        addedBook = false;

        col.isTrigger = true;

        this.tag = "Book";

        spr.sprite = originSpr;
        CheckRightPos();
    }

    public bool IsRightPos() { return rightPos; }
    public void CheckRightPos()
    {
        if (spr.sprite == rightSpr)
            Set_rightPos(true);
        else
            Set_rightPos(false);

        L_BookManager.Instance.Check_bookClear();
    }
    private void Set_rightPos(bool value) { rightPos = value; }

    public void Set_clearState()
    {
        col.enabled = false;
        Destroy(this);
    }

    public void AddBook()
    {
        col.offset = Vector2.zero;
        ((BoxCollider2D)col).size = new Vector2(0.3f, 2.23f);
        col.enabled = false;

        spr.enabled = true;

        this.tag = "P_stop";
        addedBook = false;
    }

    private void Awake()
    {
        originPos = transform.position;
        pos_y = originPos.y;

        col = GetComponent<Collider2D>();

        spr = GetComponent<SpriteRenderer>();
        originSpr = spr.sprite;
    }

    private void Start()
    {
        if (!addedBook)
            col.enabled = false;
    }

    private void OnEnable()
    {
        if (P_Camera.instance.nowPuzzle.Get_isClear())
            return;

        transform.position = originPos;

        if (addedBook)
            spr.enabled = false;
        else
            ResetPuzzle();
    }

    private void OnMouseDown()
    {
        if (addedBook) return;

        move = GameObject.Instantiate(movingBook);
        move.GetComponent<SpriteRenderer>().sprite = spr.sprite;
        move.transform.position = this.transform.position;
        spr.enabled = false;
    }

    private void OnMouseDrag()
    {
        if (move == null) return;

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;     position.y = pos_y;
        move.transform.position = position;
    }

    private void OnMouseUp()
    {
        if (move == null) return;

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] colliders = Physics2D.OverlapPointAll(position);
        foreach (Collider2D collider in colliders)
        {
            if (!collider.CompareTag("Book")) continue;
            L_BookPuzzle other = collider.GetComponent<L_BookPuzzle>();

            Sprite otherSpr = other.spr.sprite;
            other.spr.sprite = spr.sprite;  other.CheckRightPos();
            spr.sprite = otherSpr;          CheckRightPos();

            break;
        }

        spr.enabled = true;

        Destroy(move);
        move = null;
    }
}
