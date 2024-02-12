using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_AddBooks : MonoBehaviour
{
    public static L_AddBooks Instance;

    [SerializeField] private Sprite[] bookImg;
    [SerializeField] private Transform books;
    public L_BookPuzzle[] bPuzzles;

    private int bookCount;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        bookCount = 0;
    }

    private void Start()
    {
        bPuzzles = books.GetComponentsInChildren<L_BookPuzzle>();
    }

    public void ShowBook(int num)
    {
        bPuzzles[num].AddBook();
        Debug.Log((num + 1).ToString() + " Added");

        AddCount();
    }

    private void AddCount()
    {
        ++bookCount;
        if (bookCount >= 6)
            L_BookManager.Instance.SetBookPuzzle();
    }
}
