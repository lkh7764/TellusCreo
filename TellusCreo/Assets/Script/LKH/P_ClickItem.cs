using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ClickItem : MonoBehaviour
{
    private bool isToyboxPuzzle;
    private GameObject toy_after;
    private P_PuzzleInfo toyInfo;

    private bool keyA = false;
    private bool keyB = false;

    private void Awake()
    {
        toyInfo = GameObject.Find("toybox_object").GetComponent<P_PuzzleInfo>();
    }

    private void Start()
    {
        if (this.name == "puzzle_toybox_cover")
        {
            isToyboxPuzzle = true;
            toy_after = GameObject.Find("ToyBoxAfter");
        }
        else if (this.name == "item_keyA")
            keyA = true; 
        else if (this.name == "item_keyB") 
            keyB = true; 
        else
            isToyboxPuzzle = false;
    }

    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        if (P_GameManager.instance.isUp)
        {
            RaycastHit2D upHit = P_GameManager.instance.upHit;
            if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
            {
                if (isToyboxPuzzle == true)
                {
                    toyInfo.IsActive_false();
                    toyInfo.puzzleWindow = toy_after;
                    toyInfo.IsActive_true();
                }
                else
                {
                    if (upHit.collider.CompareTag("P_item"))
                    {
                        Debug.Log("Get " + this.name);
                        this.GetComponent<AudioSource>().Play();
                        if (keyA == true) { P_GameManager.instance.Set_isGetKeyA(); }
                        if (keyB == true) { P_GameManager.instance.Set_isGetKeyB(); }

                        GetComponent<SpriteRenderer>().enabled = false;
                        GetComponent<Collider2D>().enabled = false;
                    }
                    else
                        gameObject.SetActive(false);
                }
            }
        }
    }
}
