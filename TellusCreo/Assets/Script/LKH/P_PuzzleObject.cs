using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleObject : MonoBehaviour
{
    public int num = 6;

    // private P_GameManager rayController;
    private P_Camera cameraController;

    private void Awake()
    {
        // rayController = P_GameManager.instance;
        cameraController = FindObjectOfType<P_Camera>();
    }

    protected virtual P_PuzzleInfo CheckObj(RaycastHit2D hit)
    {
        GameObject clickObj = hit.collider.gameObject;
        for(int i=0; i<num; i++)
        {
            GameObject childObj = transform.GetChild(i).gameObject;
            if (System.Object.ReferenceEquals(childObj, clickObj))
                return childObj.GetComponent<P_PuzzleInfo>();
        }

        return null;
    }

    private void Update()
    {
        if (P_GameManager.instance.isUp == true)
        {
            RaycastHit2D hit = P_GameManager.instance.upHit;
            P_PuzzleInfo clickPuzzle = CheckObj(hit);
            if (clickPuzzle != null)
                cameraController.PlayPuzzle(clickPuzzle);
        }
    }
}
