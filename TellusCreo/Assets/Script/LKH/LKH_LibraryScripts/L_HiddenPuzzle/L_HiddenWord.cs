using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_HiddenWord : MonoBehaviour
{
    [SerializeField] private L_HiddenPuzzle puzzle;
    private SpriteRenderer spr;



    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
