using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_InteractionObject : P_PuzzleObject
{
    public int violinNum = 1;

    protected override P_PuzzleInfo CheckObj(RaycastHit2D hit)
    {
        GameObject clickObj = hit.collider.gameObject;
        for(int i=0; i<num; i++)
        {
            if (i == violinNum)
                continue;

            GameObject childObj = transform.GetChild(i).gameObject;
            if (System.Object.ReferenceEquals(childObj, clickObj))
                return childObj.GetComponent<P_PuzzleInfo>();
        }

        return null;
    }
}
