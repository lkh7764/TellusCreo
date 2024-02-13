using UnityEngine;

public class SetEarth : MonoBehaviour
{
    public GameObject Sunobj;
    public GameObject Soilobj;
    public GameObject Waterobj;

    public Item sunItem;
    public Item waterItem;
    public Item soilItem;

    public bool sunbool;
    public bool soilobj;
    public bool waterbool;
    void Start()
    {
        //UpdateEarthObjects();
        UpdateItem();

        sunbool = false;
        soilobj = false;
        waterbool = false;
    }

    private void OnEnable()
    {
        //UpdateEarthObjects();
        UpdateItem();
    }

    public void UpdateItem()
    {
        EarthMaterial earthMaterial = EarthMaterial.GetInstance();
        if (earthMaterial.GetSoilValue() && !soilobj)
        {
            InventoryManager.Instance.Add(soilItem);
            soilobj = true;
        }
        if (earthMaterial.GetWaterValue() && !waterbool)
        {
            InventoryManager.Instance.Add(waterItem);
            waterbool = true;
        }
        if (earthMaterial.GetSunValue() && sunbool)
        {
            InventoryManager.Instance.Add(sunItem);
            sunbool = true;
        }
    }

    public void UpdateEarthObjects()
    {
        EarthMaterial earthMaterial = EarthMaterial.GetInstance();

        if (earthMaterial.GetSoilValue())
        {
            Soilobj.SetActive(true);
        }
        else
        {
            Soilobj.SetActive(false);
        }

        if (earthMaterial.GetSunValue())
        {
            Sunobj.SetActive(true);
        }
        else
        {
            Sunobj.SetActive(false);
        }

        if (earthMaterial.GetWaterValue())
        {
            Waterobj.SetActive(true);
        }
        else
        {
            Waterobj.SetActive(false);
        }
    }
}

