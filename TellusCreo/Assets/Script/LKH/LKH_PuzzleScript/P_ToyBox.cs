using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ToyBox : MonoBehaviour
{
    private P_Camera cameraController;
    
    private int num = 1;

    private void Awake()
    {
        cameraController = FindObjectOfType<P_Camera>();
    }

    private void OnEnable()
    {
        if (cameraController.nowPuzzle.Get_IsClear() == true)
            return;

        if (P_GameManager.instance.Get_topClear() == false)
        {
            transform.GetComponentInChildren<Collider2D>().enabled = false;
            return;
        }

        transform.GetComponentInChildren<Collider2D>().enabled = true;
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (P_GameManager.instance.isUp == true)
        {
            GameObject upHit = P_GameManager.instance.upHit.collider.gameObject;
            // 여기서 오류가 발생. > hierachy창에서 수정하니까 됨. 근데 왜 된거지?
            if (System.Object.ReferenceEquals(gameObject, upHit.transform.parent.gameObject))
            {
                num++;
                if (num >= 3)
                    num = 0;

                for (int i = 0; i < 3; i++)
                {
                    this.transform.GetChild(i).gameObject.SetActive(false);
                    if (i == num)
                        this.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
}
