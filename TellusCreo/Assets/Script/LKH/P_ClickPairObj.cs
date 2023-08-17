using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class P_ClickPairObj : MonoBehaviour
{
    public GameObject pair;
    //public AudioClip changeClip;

    private AudioSource audioSource;
    //private bool changeAudio;

    private bool isDrawer;
    private bool isBedLeft;
    public bool isConnected;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        //changeAudio = false;

        if (this.gameObject.name == "drawer") { isDrawer = true; }
        else { isDrawer = false; }

        if (this.gameObject.name == "bed_left") { isBedLeft = true; }
        else { isBedLeft = false; }

        if (this.gameObject.name == "switch_before") { isConnected = true; }
        else { isConnected = false; }
    }

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (P_GameManager.instance.isUp)
        {
            GameObject hit = P_GameManager.instance.upHit.collider.gameObject;
            if (System.Object.ReferenceEquals(gameObject, hit))
            {
                if (isDrawer == true)
                {
                    if (P_GameManager.instance.Get_isGetKeyB() == false)
                    {
                        Debug.Log("need keyB");
                        audioSource.Play();
                        return;
                    }
                    //else
                    //{
                    //    if(changeAudio == false)
                    //    {
                    //        audio.clip = changeClip;
                    //        audio.Play();
                    //    }
                    //}
                }
                else if (isBedLeft == true)
                {
                    if (P_GameManager.instance.Get_isGetKeyA() == false)
                    {
                        Debug.Log("need keyA");
                        audioSource.Play();
                        return;
                    }
                }
                else if (isConnected == true)
                {
                    if (P_GameManager.instance.Get_wireConnect() == false)
                    {
                        Debug.Log("need connected wire");
                        return;
                    }
                }

                pair.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
