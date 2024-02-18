using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class livingRoomItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform parentAfterDrag;
    private string draggedItemName;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public string itemname;
    public Item item;
    string textContent;

    public List<ItemData> inventoryItems = new List<ItemData>();

    public static livingRoomItem instance;
    private string currentItem;

    private void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
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
                Debug.Log("textContent: " + textContent);
            }
        }
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(eventData.position);
        position.z = 0;
        this.transform.position = position;
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
                    case "Soil":
                        FindObjectOfType<livingroomDropzone>().UseSoil();

                        Debug.Log("Soil End");
                        break;
                    case "Water":
                        FindObjectOfType<livingroomDropzone>().UseWater();

                        Debug.Log("Water End");
                        break;
                    case "Sun":
                        FindObjectOfType<livingroomDropzone>().UseSun();

                        Debug.Log("Sun End");
                        break;
                }
                Save.GetInstance().save();

                InventoryManager.Instance.RemoveItemFromInventory(itemName);
                Destroy(gameObject);
            }
        }

        if (this.gameObject != null)
            transform.SetParent(parentAfterDrag);
    }
}
