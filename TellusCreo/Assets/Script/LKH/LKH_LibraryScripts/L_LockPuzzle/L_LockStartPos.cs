using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_LockStartPos : MonoBehaviour
{
    [SerializeField] private L_LockSlot slot;
    [SerializeField] private string compareTag;
    [SerializeField] private Vector3 resetPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(compareTag))
        {
            slot.ResetNumberPos(resetPos);
        }
    }
}
