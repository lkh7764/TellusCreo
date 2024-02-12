using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Obj { BookDrawer, PlantDrawer, SymRightDrawer, SymLeftDrawer }

public class L_ClickInteractionObj : MonoBehaviour
{
    public GameObject pair;
    private AudioSource objSound;

    [SerializeField] private Obj obj;

    private void Awake()
    {
        objSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (L_GameManager.instance.isUp == true)
        {
            RaycastHit2D upHit = L_GameManager.instance.upHit;
            int childNum = transform.childCount;
            if (childNum == 0)
            {
                ChangeObj_nonChild(upHit);
                return;
            }

            if (obj == Obj.PlantDrawer)
                ChangeObj_nonChild(upHit);
            else
                ChangeObj_child(upHit, childNum);
        }
    }

    private void ChangeObj_nonChild(RaycastHit2D hit)
    {
        if (System.Object.ReferenceEquals(hit.collider.gameObject, gameObject))
        {
            switch (obj)
            {
                case Obj.BookDrawer:
                    if (L_GameManager.instance.Get_bookClear() == false)
                    {
                        objSound.Play();
                        return;
                    }
                    break;
                case Obj.PlantDrawer:
                    if (L_GameManager.instance.isPlantDrawerLocked())
                    {
                        //objSound.Play();
                        return;
                    }
                    break;
                case Obj.SymLeftDrawer:
                    if (L_GameManager.instance.Get_symmetryClear() == false)
                    {
                        //objSound.Play();
                        return;
                    }
                    break;
                case Obj.SymRightDrawer:
                    if (L_GameManager.instance.isSymRightLock() == true)
                    {
                        // objSound.Play();
                        Debug.Log("symRight Locked");
                        return;
                    }
                    break;
            }

            pair.SetActive(true);
            gameObject.SetActive(false);
            return;
        }
    }

    private void ChangeObj_child(RaycastHit2D hit, int num)
    {
        for (int i=0; i<num; i++)
        {
            if (transform.GetChild(i).CompareTag("P_item"))
                continue;

            if (System.Object.ReferenceEquals(hit.collider.gameObject, transform.GetChild(i).gameObject))
            {
                pair.SetActive(true);
                gameObject.SetActive(false);
                return;
            }
        }
    }
}
