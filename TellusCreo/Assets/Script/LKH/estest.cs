using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estest : MonoBehaviour
{
    public SetEarth d;

    public bool soil;
    public bool sun;
    public bool water;

    private void OnMouseDown()
    {
        if (soil)
        {
            EarthMaterial.GetInstance().SetSoilValue(true);
            d.UpdateItem();
        }
        if (sun)
        {
            EarthMaterial.GetInstance().SetSunValue(true);
            d.UpdateItem();
        }
        if (water)
        {
            EarthMaterial.GetInstance().SetWaterValue(true);
            d.UpdateItem();
        }
    }
}
