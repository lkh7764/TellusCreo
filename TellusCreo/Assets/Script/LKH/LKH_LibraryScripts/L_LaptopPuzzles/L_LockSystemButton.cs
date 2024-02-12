using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_LockSystemButton : MonoBehaviour
{
    [SerializeField] private Sprite unlockImg;
    private SpriteRenderer spr;


    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp()
    {
        if (!L_GameManager.instance.isSymRightLock()) return;

        L_GameManager.instance.Set_symRightLock(false);
        spr.sprite = unlockImg;
    }
}
