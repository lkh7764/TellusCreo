using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class DroppableUI : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{ 
    
    private Image image;
    private RectTransform rect;
    public bool slotstate = false;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

public void OnPointerEnter(PointerEventData eventData)
{
    // ������ ������ ������ ��������� ����
    //image.color = Color.yellow;
}

public void OnPointerExit(PointerEventData eventData)
{
    // ������ ������ ������ �Ͼ������ ����
    //	image.color = Color.white;

}




public void OnDrop(PointerEventData eventData)
    {
         
        if(eventData.pointerDrag != null)
        {
            if(slotstate == false) {
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;

               
            }
            //eventData.pointerDrag.transform.SetParent(transform);
            //eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }
    }
    // Start is called before the first frame update
    
}
