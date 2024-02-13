using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_BookManager : MonoBehaviour
{
    public static L_BookManager Instance;
    private L_BookPuzzle[] books;

    public GameObject backgroundBooks1;
    public GameObject backgroundBooks2;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        books = this.GetComponentsInChildren<L_BookPuzzle>();
    }

    public void Check_bookClear()
    {
        bool clear = true;
        foreach (L_BookPuzzle book in books)
        {
            if (!book.IsRightPos())
            {
                clear = false;
                break;
            }
        }

        if (clear)
            Set_bookClear();
    }

    private void Set_bookClear()
    {
        L_GameManager.instance.Set_bookClear();
        foreach (L_BookPuzzle book in books)
            book.Set_clearState();

        Debug.Log("BookClear");
    }

    public void SetBookPuzzle()
    {
        foreach (L_BookPuzzle b in books)
            b.ResetPuzzle();

        backgroundBooks1.SetActive(false);
        backgroundBooks2.SetActive(true);

        Destroy(L_AddBooks.Instance);
    }
}
