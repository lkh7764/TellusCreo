﻿using System.Collections;
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

    private bool allClear = false;


    private void Start()
    {
        this.tag = "Soil";
        soil.SetActive(false);
        water.SetActive(false);
        sun.SetActive(false);

        CheckClear();
        Save.GetInstance().save();
    }

    private void CheckClear()
    {
        if (EarthMaterial.GetInstance().GetSoilValue())
        {
            if (EarthMaterial.GetInstance().GetUseSoil())
            {
                UseSoil();
            }
            else
            {
                soil.SetActive(false);
                Debug.Log("soil added");
                UpdateItem("soil");
                return;
            }
        }

        if (EarthMaterial.GetInstance().GetWaterValue())
        {
            if (EarthMaterial.GetInstance().GetUseWater())
            {
                UseWater();
            }
            else
            {
                Debug.Log("water added");
                water.SetActive(false);
                UpdateItem("water");
                return;
            }
        }

        if (EarthMaterial.GetInstance().GetSunValue())
        {
            if (EarthMaterial.GetInstance().GetUseSun())
            {
                UseSun();
            }
            else
            {
                Debug.Log("sun added");
                sun.SetActive(false);
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
        soil.SetActive(true);
        water.SetActive(true);
        EarthMaterial.GetInstance().SetUseWater(true);
        this.tag = "Sun";
    }

    public void UseSun()
    {
        EarthMaterial.GetInstance().SetUseSun(true);
        soil.SetActive(true);
        water.SetActive(true);
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

    private IEnumerator Knock()
    {
        yield return new WaitForSeconds(3.0f);
        //au.Play();
    }
}
