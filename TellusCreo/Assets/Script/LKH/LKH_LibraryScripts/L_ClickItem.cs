using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class L_ClickItem : MonoBehaviour
{
    [SerializeField] private GameObject pair;
    private bool hasPair;

    public Item Item;


    private void Awake()
    {
        if (pair == null)
            hasPair = false;
        else
            hasPair = true;
    }

    public void Pickup()
    {
        InventoryManager.Instance.Add(Item);

        Debug.Log("asdf");
        if (SoundManager.Instance != null)
            SoundManager.Instance.Play("item_get");

        if (hasPair)
            Destroy(pair);

        Destroy(gameObject);
    }


    private void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!CompareTag("P_item"))
            return;

        Pickup();
    }
}
