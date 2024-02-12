using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_LockSelectSlot : MonoBehaviour
{
    [SerializeField] private L_LockSlot slot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(this.tag))
        {
            slot.Set_isRightPos();
        }
    }
}
