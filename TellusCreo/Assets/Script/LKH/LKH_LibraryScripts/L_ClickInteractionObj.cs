using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ClickInteractionObj : MonoBehaviour
{
    public GameObject pair;
    private AudioSource objSound;

    private bool isBookDrawer = false;

    private void Awake()
    {
        objSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (gameObject.name == "bookDrawer_close")
            isBookDrawer = true;
    }

    void Update()
    {
        if (L_GameManager.instance.isUp == true)
        {
            RaycastHit2D upHit = L_GameManager.instance.upHit;

            int childNum = transform.childCount;
            if (childNum == 0)
            {
                if (System.Object.ReferenceEquals(upHit.collider.gameObject, gameObject))
                {
                    if(isBookDrawer == true)
                    {
                        if (L_GameManager.instance.Get_bookClear() == false)
                        {
                            objSound.Play();
                            return;
                        }
                    }

                    pair.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < childNum; i++)
                {
                    // 인벤토리 설정에 따라 조건 바꾸기
                    if (transform.GetChild(i).CompareTag("P_item"))
                        continue;

                    if (System.Object.ReferenceEquals(upHit.collider.gameObject, transform.GetChild(i).gameObject))
                    {
                        pair.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
