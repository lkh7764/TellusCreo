using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Wire : MonoBehaviour
{
    public GameObject rightItem;
    public GameObject connectWire;

    public bool isPlantDrawer = false;

    private void Start()
    {
        if (gameObject.name == "plantDrawer_close")
            isPlantDrawer = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (System.Object.ReferenceEquals(collision.gameObject, rightItem))
        {
            if (isPlantDrawer == true)
            {
                GetComponent<L_ClickInteractionObj>().Set_isLocked_plant();
                collision.gameObject.SetActive(false);
                return;
            }

            P_GameManager.instance.Set_wireConnect();
            connectWire.SetActive(true);
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
