using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_BookManager : MonoBehaviour
{
    public static L_BookManager Instance;
    private L_BookPuzzle[] books;

    [SerializeField] private GameObject backgroundBook1;
    [SerializeField] private GameObject backgroundBook2;



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

        backgroundBook1.SetActive(false);
        backgroundBook2.SetActive(true);

        Destroy(L_AddBooks.Instance);
    }
}
