using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attic_sun : MonoBehaviour
{
    public GameObject emptySun;


    private void OnDestroy()
    {
        if (EarthMaterial.GetInstance() != null)
        {
            emptySun.SetActive(true);
            SoundManager.Instance.Play("item_get");
            Debug.Log("Attic clearclearclear");
            EarthMaterial.GetInstance().SetSunValue(true);
        }
    }
}
