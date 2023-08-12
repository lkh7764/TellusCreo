using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ClickItem : MonoBehaviour
{
    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (L_GameManager.instance.isUp == true)
        {
            RaycastHit2D upHit = L_GameManager.instance.upHit;

            int childNum = transform.childCount;
            if (childNum == 0)
            {
                if (System.Object.ReferenceEquals(upHit.collider.gameObject, gameObject))
                {
                    Debug.Log("get " + name);
                    gameObject.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < childNum; i++)
                {
                    if (System.Object.ReferenceEquals(upHit.collider.gameObject, transform.GetChild(i).gameObject))
                    {
                        Debug.Log("get " + name);
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
