using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_OjakgyoPuzzle : MonoBehaviour
{
    public static L_OjakgyoPuzzle instance;
    [SerializeField] private L_OjakgyoFolder finishFolder;
    public Transform movableFolders;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void Check_ojakgyoClear()
    {
        if (finishFolder.IsConnected())
            Set_ojakgyoClear();
    }

    private void Set_ojakgyoClear()
    {
        L_GameManager.instance.Set_ojakgyoClear(true);
        L_OjakgyoFolder[] folders = movableFolders.GetComponentsInChildren<L_OjakgyoFolder>();
        for (int i = 0; i < folders.Length; i++)
            folders[i].Set_ClearState();
    }
}
