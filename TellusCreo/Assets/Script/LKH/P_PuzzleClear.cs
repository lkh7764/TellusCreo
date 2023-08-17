using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleClear : MonoBehaviour
{
    private int length;

    public GameObject puzzleObj;
    private P_PuzzleInfo puzzleInfo;

    private AudioSource clearAudio;

    private bool isDollPuzzle2 = false;

    public GameObject keyB;

    private void Awake()
    {
        puzzleInfo = puzzleObj.GetComponent<P_PuzzleInfo>();
        clearAudio = puzzleObj.GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (gameObject.name == "DollPuzzle2")
            isDollPuzzle2 = true;
    }

    private void ClearCondition()
    {
        //if (System.Object.ReferenceEquals(puzzleObj, tower))
        //{
        //    if (puzzleCopy.transform.Find("clearZone").GetComponent<P_TowerClearZone>().isRight == true)
        //    {
        //        GetComponent<P_PuzzleObject>().isClear = true;
        //        Rigidbody2D[] rigs = GetComponent<P_PuzzleObject>().puzzleClear.GetComponentsInChildren<Rigidbody2D>();
        //        foreach (Rigidbody2D rig in rigs)
        //        {
        //            Destroy(rig);
        //        }
        //        keyB.SetActive(true);
        //        Destroy(this.GetComponent<P_PuzzleClear>());
        //        this.GetComponent<AudioSource>().Play();
        //    }
        //}
        //else if (System.Object.ReferenceEquals(puzzleObj, top))
        //{
        //    MonoBehaviour[] scripts = puzzleCopy.GetComponentsInChildren<P_Rotation>();
        //    length = scripts.Length;
        //    foreach (MonoBehaviour script in scripts)
        //    {
        //        if (script.GetComponent<P_Rotation>().isRotation == false) { break; }
        //        else
        //        {
        //            if (script == scripts[length - 1])
        //            {
        //                GetComponent<P_PuzzleObject>().isClear = true;
        //                FindObjectOfType<P_GameManager>().Set_topClear();
        //                Destroy(this.GetComponent<P_PuzzleClear>());
        //                this.GetComponent<AudioSource>().Play();
        //            }
        //        }
        //    }
        //}
        //foreach (MonoBehaviour script in scripts)
        //{
        //    if (script.GetComponent<P_IsRightPos>().isRight == false) { break; }
        //    else
        //    {
        //        if (script == scripts[length - 1])
        //        {
        //            //Debug.Log("last script");
        //            GetComponent<P_PuzzleObject>().isClear = true;
        //            if (isDollPuzzle)
        //            {
        //                gameManager.RotateStick();
        //                gameManager.Set_dollClear();
        //            }
        //            Destroy(this.GetComponent<P_PuzzleClear>());
        //            this.GetComponent<AudioSource>().Play();
        //        }
        //    }
        //}
    }

    public void CheckClear()
    {
        P_IsRightPos[] scripts = GetComponentsInChildren<P_IsRightPos>();
        length = scripts.Length;

        foreach (P_IsRightPos script in scripts)
        {
            if (script.isRight == false) { break; }
            else
            {
                if (script == scripts[length - 1])
                {
                    puzzleInfo.IsClear_true();
                    clearAudio.Play();

                    Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
                    foreach (Collider2D collider in colliders)
                        collider.enabled = false;

                    if (isDollPuzzle2 == true)
                        P_GameManager.instance.Set_dollClear();

                    Destroy(this);
                }
            }
        }
    }

    public void CheckClear_TopPuzzle()
    {
        P_Rotation[] scripts = transform.GetComponentsInChildren<P_Rotation>();
        length = scripts.Length;
        foreach (P_Rotation script in scripts)
        {
            if (script.isRotation == false)
                break;
            else
            {
                if (script == scripts[length - 1])
                {
                    puzzleInfo.IsClear_true();
                    clearAudio.Play();

                    Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
                    foreach (Collider2D collider in colliders)
                        collider.enabled = false;

                    P_GameManager.instance.Set_topClear();

                    Destroy(this);
                }
            }
        }
    }

    public void CheckClear_TowerPuzzle()
    {
        P_TowerClearZone clear = transform.GetComponentInChildren<P_TowerClearZone>();
        if (clear.isRight == true)
        {
            puzzleInfo.IsClear_true();
            clearAudio.Play();

            Rigidbody2D[] rigs = GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rig in rigs)
                Destroy(rig);

            Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
            foreach (Collider2D collider in colliders)
                collider.enabled = false;

            keyB.SetActive(true);

            Destroy(clear);
            Destroy(this);
        }
    }
}
