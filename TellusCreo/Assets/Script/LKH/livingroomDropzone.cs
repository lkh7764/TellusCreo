using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livingroomDropzone : MonoBehaviour
{
    public GameObject soil;
    public GameObject water;
    public GameObject sun;

    public Item sunItem;
    public Item waterItem;
    public Item soilItem;


    private void Start()
    {
        this.tag = "Soil";
        soil.SetActive(false);
        water.SetActive(false);
        sun.SetActive(false);

        CheckClear();
    }

    private void CheckClear()
    {
        if (EarthMaterial.GetInstance().GetSoilValue())
        {
            if (EarthMaterial.GetInstance().GetUseSoil())
                UseSoil();
            else
            {
                Debug.Log("soil added");
                UpdateItem("soil");
                return;
            }
        }
        
        if (EarthMaterial.GetInstance().GetWaterValue())
        {
            if (EarthMaterial.GetInstance().GetUseWater())
                UseWater();
            else
            {
                Debug.Log("water added");
                UpdateItem("water");
                return;
            }
        }
        
        if (EarthMaterial.GetInstance().GetSunValue())
        {
            if (EarthMaterial.GetInstance().GetUseSun())
                UseWater();
            else
            {
                Debug.Log("sun added");
                UpdateItem("sun");
                return;
            }
        }


    }

    public void UseSoil()
    {
        soil.SetActive(true);
        EarthMaterial.GetInstance().SetUseSoil(true);
        this.tag = "Water";
    }

    public void UseWater()
    {
        water.SetActive(true);
        EarthMaterial.GetInstance().SetUseWater(true);
        this.tag = "Sun";
    }

    public void UseSun()
    {
        EarthMaterial.GetInstance().SetUseSun(true);
        sun.SetActive(true);
    }

    public void UpdateItem(string name)
    {
        InventoryManager.Instance.ResetInventory();

        switch (name)
        {
            case "soil":
                Debug.Log("inventory soil added");
                InventoryManager.Instance.Add(soilItem);
                break;
            case "water":
                Debug.Log("inventory water added");
                InventoryManager.Instance.Add(waterItem);
                break;
            case "sun":
                Debug.Log("inventory sun added");
                InventoryManager.Instance.Add(sunItem);
                break;
        }
    }
}
