using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_UI : MonoBehaviour
{
    public void ClickLeftArrow()
    {
        P_Camera.instance.MoveSide(0);
        SoundManager.Instance.Play("light_switch");
        PlayMenuClickSound();
    }

    public void ClickRightArrow()
    {
        P_Camera.instance.MoveSide(1);
        SoundManager.Instance.Play("light_switch");
        PlayMenuClickSound();
    }

    public void ClickBackArrow()
    {
        P_Camera.instance.ExtiPuzzle();
        SoundManager.Instance.Play("mouse-click-153941");
        PlayMenuClickSound();
    }

    private void PlayMenuClickSound()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>(); // AudioManager 스크립트를 찾아야 합니다.

        if (audioManager != null)
        {
            audioManager.PlayMenuClickSound();
        }
        else
        {
            Debug.LogWarning("AudioManager not found.");
        }
    }
}