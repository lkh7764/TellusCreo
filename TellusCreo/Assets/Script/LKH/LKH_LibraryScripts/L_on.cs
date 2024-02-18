using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_on : MonoBehaviour
{
    public static L_on Instance;

    [SerializeField] private Collider2D windowCollider;
    [SerializeField] private GameObject fullCup;

    [SerializeField] private Collider2D plantCollider;
    [SerializeField] private L_PlantGrow plantGrow;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void On1()
    {
        windowCollider.enabled = false;
        fullCup.SetActive(true);
    }

    public void On2()
    {
        plantCollider.enabled = false;
        plantGrow.StartGrowing();
    }

    public void On3()
    {
        L_GameManager.instance.Set_plantDrawerLocked();
        // 열리는 소리 추가
    }

    public void On4(string name)
    {
        switch (name)
        {
            case "Book1":
                L_AddBooks.Instance.ShowBook(0);
                break;
            case "Book2":
                L_AddBooks.Instance.ShowBook(1);
                break;
            case "Book3":
                L_AddBooks.Instance.ShowBook(2);
                break;
            case "Book4":
                L_AddBooks.Instance.ShowBook(3);
                break;
            case "Book5":
                L_AddBooks.Instance.ShowBook(4);
                break;
            case "Book6":
                L_AddBooks.Instance.ShowBook(5);
                break;
        }
        SoundManager.Instance.Play("puzzle_wire_connect");
    }
}
