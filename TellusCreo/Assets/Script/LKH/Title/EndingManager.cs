using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    float time = 18.5f;

    public void Start()
    {
        StartCoroutine(ResetGame());
    }

    public IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(time);

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Title");
    }
}
