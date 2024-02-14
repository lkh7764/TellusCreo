using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clcickcdfa : MonoBehaviour
{
    public GameObject pair;

    private void OnMouseUp()
    {
        if (!GameManager.Instance.Get_arcadeClear())
        {
            SoundManager.Instance.Play("door_locked");
            return;
        }

        pair.SetActive(true);
        gameObject.SetActive(false);
        return;
    }
}
