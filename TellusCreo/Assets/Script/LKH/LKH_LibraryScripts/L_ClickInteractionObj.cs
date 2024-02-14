using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


enum Obj { BookDrawer, PlantDrawer, SymRightDrawer, SymLeftDrawer, Door,Arcade }

public class L_ClickInteractionObj : MonoBehaviour
{
    public GameObject pair;
    [SerializeField] private Obj obj;


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
                    if (!L_GameManager.instance.Get_bookClear())
                    {
                        SoundManager.Instance.Play("door_locked");
                        return;
                    }
                    SoundManager.Instance.Play("open_lockedDoor");
                    break;
                case Obj.PlantDrawer:
                    if (L_GameManager.instance.isPlantDrawerLocked())
                    {
                        SoundManager.Instance.Play("door_locked");
                        return;
                    }
                    SoundManager.Instance.Play("door_sliding");
                    break;
                case Obj.SymLeftDrawer:
                    if (!L_GameManager.instance.Get_symmetryClear())
                    {
                        SoundManager.Instance.Play("door_locked");
                        return;
                    }
                    SoundManager.Instance.Play("open_lockedDoor");
                    break;
                case Obj.SymRightDrawer:
                    if (L_GameManager.instance.isSymRightLock())
                    {
                        SoundManager.Instance.Play("door_locked");
                        Debug.Log("symRight Locked");
                        return;
                    }
                    SoundManager.Instance.Play("open_lockedDoor");
                    break;
                case Obj.Door:
                    if (L_GameManager.instance.IsGetFinalItem())
                    {
                        SoundManager.Instance.Play("open_lockedDoor");

                        EarthMaterial.GetInstance().SetWaterValue(true);
                        SceneManager.LoadScene("livingroom");
                    }
                    else
                    {
                        SoundManager.Instance.Play("door_locked");
                        return;
                    }
                    break;
                case Obj.Arcade:
                    if (!GameManager.Instance.Get_arcadeClear())
                    {
                        SoundManager.Instance.Play("door_locked");
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
