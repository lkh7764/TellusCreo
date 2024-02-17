using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum FolderType { defualt, start, finish }
public class L_OjakgyoFolder : MonoBehaviour
{
    public GameObject movingFolder;
    private GameObject move;

    [SerializeField] private FolderType type;
    [SerializeField] private bool connected;
    [SerializeField] private bool empty;

    private Vector3[] poses;
    private SpriteRenderer spr;
    private Collider2D col;

    private float interval_x = 1.4f;
    private float interval_y = 1.3f;



    private void Awake()
    {
        if (type == FolderType.start)
            connected = true;
        else
            connected = false;
    }

    void Start()
    {
        Set_poses();

        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        if (empty)
            spr.enabled = false;
        else
            Check_connected();
    }

    private void OnEnable()
    {
        move = null;
    }

    private void OnMouseDown()
    {
        if (empty) return;
        if (type != FolderType.defualt) return;

        move = GameObject.Instantiate(movingFolder);
        movingFolder.transform.position = this.transform.position;
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
            if (!collider.CompareTag("Folder")) continue;
            L_OjakgyoFolder folder = collider.GetComponent<L_OjakgyoFolder>();
            if (!folder.IsEmpty()) continue;
            Set_empty(true);
            folder.Set_empty(false);
            break;
        }

        move.transform.position = new Vector3(0.0f, 50.0f, 0.0f);
        Destroy(move);
        move = null;
    }

    private void Set_poses()
    {
        Vector3 pos = transform.position;
        poses = new Vector3[4];

        poses[0] = new Vector3(pos.x - interval_x, pos.y, pos.z);
        poses[1] = new Vector3(pos.x + interval_x, pos.y, pos.z);
        poses[2] = new Vector3(pos.x, pos.y - interval_y, pos.z);
        poses[3] = new Vector3(pos.x, pos.y + interval_y, pos.z);

        Debug.Log("set poses");
    }

    private void Check_connected()
    {
        int test1 = 1;
        foreach (Vector3 pos in poses)
        {
            Debug.Log(test1.ToString() + "pos");
            ++test1;
            Collider2D[] colliders = Physics2D.OverlapPointAll(pos);
            foreach (Collider2D collider in colliders)
            {
                if (!collider.CompareTag("Folder"))
                {
                    Debug.Log("not folder");
                    continue;
                }
                L_OjakgyoFolder folder = collider.GetComponent<L_OjakgyoFolder>();
                if (folder.IsEmpty())
                {
                    Debug.Log("folder empty");
                    continue;
                }
                if (!folder.IsConnected())
                {
                    Debug.Log("not connected");
                    continue;
                }

                Set_connected(true);
                return;
            }
        }
    }

    public void Set_connected(bool value)
    {
        connected = value;
        switch (connected)
        {
            case true:
                Debug.Log("Set connected");
                foreach (Vector3 pos in poses)
                {
                    Collider2D[] colliders = Physics2D.OverlapPointAll(pos);
                    foreach (Collider2D collider in colliders)
                    {
                        if (!collider.CompareTag("Folder")) continue;
                        L_OjakgyoFolder folder = collider.GetComponent<L_OjakgyoFolder>();
                        if (folder.IsEmpty()) continue;
                        if (folder.IsConnected()) continue;
                        folder.Set_connected(true);
                    }
                }
                break;
            case false:
                Debug.Log("Set connected false");
                foreach (Vector3 pos in poses)
                {
                    Collider2D[] colliders = Physics2D.OverlapPointAll(pos);
                    foreach (Collider2D collider in colliders)
                    {
                        if (!collider.CompareTag("Folder")) continue;
                        L_OjakgyoFolder folder = collider.GetComponent<L_OjakgyoFolder>();
                        if (folder.IsEmpty()) continue;
                        if (!folder.IsConnected()) continue;
                        folder.Check_connected();
                    }
                }
                break;
        }

        L_OjakgyoPuzzle.instance.Check_ojakgyoClear();
    }
    public bool IsConnected() { return connected; }

    public void Set_ClearState()
    {
        col.enabled = false;
        Destroy(this);
    }

    public bool IsEmpty() { return empty; }
    public void Set_empty(bool value)
    {
        empty = value;
        switch (empty)
        {
            case false:
                spr.enabled = true;
                Check_connected();
                break;
            case true:
                spr.enabled = false;
                if (connected)
                    Set_connected(false);
                break;
        }
    }
}
