using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ObjType { Defualt, Slim }

public class L_SymObj : MonoBehaviour
{
    private Vector3 pos;

    private Collider2D col;

    public GameObject movingObj;
    private GameObject move;

    [SerializeField] private Sprite rightSpr;
    public SpriteRenderer spr;
    private Sprite originSpr;

    private bool rightPos;
    private bool readyToPuzzle;

    public ObjType type;


    private void Awake()
    {
        pos = this.transform.position;

        col = GetComponent<Collider2D>();

        move = null;

        spr = GetComponent<SpriteRenderer>();
        originSpr = spr.sprite;

        rightPos = false;
        readyToPuzzle = false;
    }

    public void InitializeObj()
    {
        col.enabled = false;
        spr.enabled = true;

        readyToPuzzle = false;
    }

    public bool IsRightPos() { return rightPos; }
    public void CheckRightPos()
    {
        if (spr.sprite == rightSpr)
            Set_rightPos(true);
        else
            Set_rightPos(false);

        L_SymmetryPuzzle.Instance.Check_symClear();
    }
    private void Set_rightPos(bool value) { rightPos = value; }

    public void Set_clearState()
    {
        col.enabled = false;
        Destroy(this);
    }

    public void Set_puzzleState()
    {
        col.enabled = true;
        spr.enabled = true;
        spr.sprite = originSpr;

        move = null;

        readyToPuzzle = true;

        this.tag = "Sym";

        CheckRightPos();
    }

    private void OnMouseDown()
    {
        if (!readyToPuzzle) return;

        move = GameObject.Instantiate(movingObj);
        move.GetComponent<SpriteRenderer>().sprite = spr.sprite;
        move.transform.position = pos;
        spr.enabled = false;
    }

    private void OnMouseDrag()
    {
        if (move == null) return;

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        move.transform.position = position;
    }

    private void OnMouseUp()
    {
        if (move == null) return;

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] colliders = Physics2D.OverlapPointAll(position);
        foreach (Collider2D collider in colliders)
        {
            if (!collider.CompareTag("Sym")) continue;
            L_SymObj other = collider.GetComponent<L_SymObj>();
            if (type != other.type) continue;

            Sprite otherSpr = other.spr.sprite;
            other.spr.sprite = spr.sprite; other.CheckRightPos();
            spr.sprite = otherSpr; CheckRightPos();

            break;
        }

        spr.enabled = true;

        Destroy(move);
        move = null;
    }
}
