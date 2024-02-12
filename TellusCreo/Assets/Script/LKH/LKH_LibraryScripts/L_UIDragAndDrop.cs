using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class L_UIDragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform parentAfterDrag;
    private string draggedItemName;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public string itemname;
    public Item item;
    string textContent;

    public List<ItemData> inventoryItems = new List<ItemData>();

    public static L_UIDragAndDrop instance;


    private SpriteRenderer puzzleviolinRenderer;

    private string currentItem;

    private bool candle;

    private void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        candle = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ItemDataBase itemDatabase = GameObject.Find("ItemDataBase").GetComponent<ItemDataBase>();

        foreach (ItemData itemData in itemDatabase.itemDB)
        {
            inventoryItems.Add(itemData);
        }

        GameObject draggedObject = eventData.pointerDrag;
        if (draggedObject != null)
        {
            Text textComponent = draggedObject.GetComponentInChildren<Text>();

            if (textComponent != null)
            {
                textContent = textComponent.text;
                Debug.Log(textContent);
            }
        }
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;

        if (textContent == "Candle")
            candle = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(eventData.position);
        position.z = 0;
        this.transform.position = position;

        if (!candle) return;
        Vector3 dropPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dropPosition.z = 0f;
        Collider2D[] colliders = Physics2D.OverlapPointAll(dropPosition);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(textContent))
            {
                string itemName = textContent;
                switch (textContent)
                {
                    case "Candle":
                        Debug.Log("Candle");
                        break;
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        Vector3 dropPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dropPosition.z = 0f;
        List<Item> Items = InventoryManager.Instance.GetItems();
        Collider2D[] colliders = Physics2D.OverlapPointAll(dropPosition);

        foreach (Collider2D collider in colliders)
        {
            // 다른 오브젝트와의 충돌 판정을 수행하고 원하는 동작을 수행합니다.
            if (collider.CompareTag(textContent))
            {
                string itemName = textContent;
                switch (textContent)
                {
                    case "Cup":
                        Debug.Log("Cup End");
                        L_on.Instance.On1();
                        break;
                    case "WaterCup":
                        Debug.Log("WaterCup End");
                        L_on.Instance.On2();
                        break;
                    case "PlantKey":
                        Debug.Log("PlantKey End");
                        L_on.Instance.On3();
                        break;
                    case "Trophy":
                        Debug.Log("PlantKey End");
                        L_SymmetryPuzzle.Instance.Set_symPuzzle();
                        break;
                    case "Book1":
                        Debug.Log("Book end");
                        L_on.Instance.On4(textContent);
                        break;
                    case "Book2":
                        Debug.Log("Book end");
                        L_on.Instance.On4(textContent);
                        break;
                    case "Book3":
                        Debug.Log("Book end");
                        L_on.Instance.On4(textContent);
                        break;
                    case "Book4":
                        Debug.Log("Book end");
                        L_on.Instance.On4(textContent);
                        break;
                    case "Book5":
                        Debug.Log("Book end");
                        L_on.Instance.On4(textContent);
                        break;
                    case "Book6":
                        Debug.Log("Book end");
                        L_on.Instance.On4(textContent);
                        break;
                }
                InventoryManager.Instance.RemoveItemFromInventory(itemName);
                Destroy(gameObject);
            }
        }

        if (this.gameObject != null)
            transform.SetParent(parentAfterDrag);

        L_GameManager.instance.isUp = false;
    }
}
