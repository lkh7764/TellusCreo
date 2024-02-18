﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(GameManager.Instance!=null)
        {
            if (GameManager.Instance.ClearAttic)
            {
                SceneManager.LoadScene("livingRoom");
                EarthMaterial.GetInstance().SetSunValue(true);
                Save.GetInstance().save();
            }
            else
            {
                Debug.Log("다락방 미완료");
                SoundManager.Instance.Play("door_locked");
            }
        }
    }
}
