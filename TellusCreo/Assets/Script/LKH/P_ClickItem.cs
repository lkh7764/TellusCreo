using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_ClickItem : MonoBehaviour
{
    private bool isToyboxPuzzle = false;
    public GameObject toy_after;
    private P_PuzzleInfo toyInfo;

    private bool keyA = false;
    private bool keyB = false;
    private bool finalItem = false;
    private bool finalDoor = false;

    private void Awake()
    {
        toyInfo = GameObject.Find("toybox_object").GetComponent<P_PuzzleInfo>();
    }

    private void Start()
    {
        if (gameObject.name == "puzzle_toybox_cover")
            isToyboxPuzzle = true;
        else if (gameObject.name == "item_keyA")
            keyA = true;
        else if (gameObject.name == "item_keyB")
            keyB = true;
        else if (gameObject.name == "item_final_soil")
            finalItem = true;
        else if (gameObject.name == "finalDoor_object")
            finalDoor = true;
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
                    return;
                }               
                else if (finalItem == true)
                {
                    P_GameManager.instance.Set_isGetFinalItem();
                    gameObject.SetActive(false);
                    return;
                }
                else if (finalDoor == true)
                {
                    bool isPlayroomClear = P_GameManager.instance.Get_isGetFinalItem();
                    if(isPlayroomClear == true)
                    {
                        SceneManager.LoadScene("livingroom");
                    }
                    else
                    {
                        Debug.Log("need final item");
                        GetComponent<AudioSource>().Play();
                    }
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
                        return;
                    }
                    else
                        gameObject.SetActive(false);
                }
            }
        }
    }
}
