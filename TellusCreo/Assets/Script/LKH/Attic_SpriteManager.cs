using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attic_SpriteManager : MonoBehaviour
{
    public static Attic_SpriteManager i;

    [SerializeField] private SpriteRenderer launcher;
    [SerializeField] private DustMirror mirror;


    private void Awake()
    {
        if (i == null)
            i = this;
        else
            Destroy(this);
    }

    public void On1()
    {
        launcher.enabled = true;
        GameManager.Instance.Set_starLauncher();
    }

    public void On2()
    {
        mirror.On(); 
    }
}
