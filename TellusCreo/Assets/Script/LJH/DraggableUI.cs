
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private RectTransform rect;
    private Transform previousParent; //���� �θ� ������Ʈ
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect =GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        //�巡�� ������ �ҼӵǾ� �ִ� �θ� Transform ���� ����
        previousParent = transform.parent;

        // ���� �巡������ UI�� ȭ���� �ֻ�ܿ� ��µǵ��� �ϱ� ����
        transform.SetParent(canvas);
        // �θ� ������Ʈ�� Canvas�� ����
        transform.SetAsLastSibling();        // ���� �տ� ���̵��� ������ �ڽ����� ����

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
        //GetComponent<TextFolder>().state=false;
        
    }

    public void OnEndDrag(PointerEventData eventData) {

        // �巡�׸� �����ϸ� �θ� canvas�� �����Ǳ� ������
        // �巡�׸� ������ �� �θ� canvas�̸� ������ ������ �ƴ� ������ ����
        // ����� �ߴٴ� ���̱� ������ �巡�� ������ �ҼӵǾ� �ִ� ������ �������� ������ �̵�
        if (transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rect.position=previousParent.GetComponent<RectTransform>().position;
          
        }

        if (transform.parent.transform.childCount >= 2)     //�̹� ���Կ� �ڽ��� 1���̻� ���� �� 
        {

            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;    //���� �θ� �������� ���ư��� �ڵ�  


        }
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts= true;
    }

    public void OnDrop(PointerEventData eventData)
    {


        ///pointerDrag�� ���� �巡���ϰ� �ִ� ���(= ������)
        //if(transform.parent.transform.childCount >= 1)     //�̹� ���Կ� �ڽ��� 1���̻� ���� �� 
        //    {

        //            transform.SetParent(previousParent);
        //            rect.position = previousParent.GetComponent<RectTransform>().position;    //���� �θ� �������� ���ư��� �ڵ�  


        //    }

        if (eventData.pointerDrag != null)
        {

            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;





            //    // �巡���ϰ� �ִ� ����� �θ� ���� ������Ʈ�� �����ϰ�, ��ġ�� ���� ������Ʈ ��ġ�� �����ϰ� ����
            //    //eventData.pointerDrag.transform.SetParent(transform);
            //    //eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            //}
        }


    }
}
