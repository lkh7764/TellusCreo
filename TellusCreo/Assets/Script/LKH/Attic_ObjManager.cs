using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attic_ObjManager : MonoBehaviour
{
    public static Attic_ObjManager ins;
    public Transform windows;

    public bool OnObj = false;


    private void Awake()
    {
        if (ins == null)
            ins = this;
        else
        {
            Debug.Log("adsf");
            Destroy(this);
        }
    }

    public void ChangeBackground()// 카메라 이동
    {
        if (!GameManager.Instance.onPuzzle)
        {
            GameManager.Instance.Ui.prevCameraPos = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(25f, -25f, -100f);
            GameManager.Instance.Ui.ActiveBackArrow();
            GameManager.Instance.onPuzzle = true;
        }

        OnObj = true;
    }

    public void ResetWindow()
    {
        for(int i=0; i<windows.childCount; i++)
            windows.GetChild(i).gameObject.SetActive(false);

        OnObj = false;
    }
}
