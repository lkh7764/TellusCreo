﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject Image;
    public Transform ItemDropZone;
    public GameObject itemItem;
    public GameObject beforeItem;

    private bool isDragging = false;
    private bool isDropped = false;

    public void OnDrag(PointerEventData eventData)
    {
        if (isDropped)
            return;

        isDragging = true;
        Image.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;


        if (RectTransformUtility.RectangleContainsScreenPoint(ItemDropZone.GetComponent<RectTransform>(), eventData.position))
        {
            Image.transform.SetParent(ItemDropZone);
            Image.transform.position = ItemDropZone.position;


            itemItem.SetActive(true);
            Image.SetActive(false);
            beforeItem.SetActive(false);
            isDropped = true;
        }
        else
        {

            Image.transform.SetParent(transform);
            Image.transform.localPosition = Vector3.zero;
        }
    }
}