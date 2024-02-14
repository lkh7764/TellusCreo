using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Attic_obj : MonoBehaviour
{
    private bool clicked = false;
    [SerializeField] private GameObject pair;

    private void OnMouseDown()
    {
        clicked = true;
    }

    private void OnMouseUp()
    {
        if (!clicked) return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;


        Attic_ObjManager.ins.ChangeBackground();
        pair.SetActive(true);
        clicked = false;
    }
}
