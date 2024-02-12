using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_SymmetryPuzzle : MonoBehaviour
{
    public static L_SymmetryPuzzle Instance;
    private L_SymObj[] objs;

    [SerializeField] private GameObject trophy;
    public bool readyToPuzzle;
    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        objs = this.GetComponentsInChildren<L_SymObj>();

        foreach (L_SymObj obj in objs)
            obj.InitializeObj();

        trophy.GetComponent<Collider2D>().enabled = true;
        trophy.GetComponent<SpriteRenderer>().enabled = false;

        readyToPuzzle = false;
    }

    public void Check_symClear()
    {
        bool clear = true;
        foreach (L_SymObj obj in objs)
        {
            if (!obj.IsRightPos())
            {
                clear = false;
                break;
            }
        }

        if (clear)
            Set_symClear();
    }
    private void Set_symClear()
    {
        L_GameManager.instance.Set_symmetryClear();
        foreach (L_SymObj obj in objs)
            obj.Set_clearState();

        Debug.Log("BookClear");
    }

    public void Set_symPuzzle()
    {
        foreach (L_SymObj obj in objs)
            obj.Set_puzzleState();

        readyToPuzzle = true;
    }

    private void OnEnable()
    {
        if (P_Camera.instance.nowPuzzle.Get_isClear())
            return;
        if (!readyToPuzzle)
            return;

        foreach (L_SymObj obj in objs)
            obj.Set_puzzleState();
    }
}
