using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_PasswordHint : MonoBehaviour
{
    [SerializeField] private GameObject hintWindow;

    private void Awake()
    {
        hintWindow.SetActive(false);
    }

    private void OnMouseUp()
    {
        P_Camera.instance.ShowHintWindow(hintWindow);
    }
}
