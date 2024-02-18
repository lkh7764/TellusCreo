using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelButtons : MonoBehaviour
{
    public enum ButtonType { Exit, Reset}
    public ButtonType type;

    public void ClickButton()
    {
        if (type == ButtonType.Exit)
        {
            Save.GetInstance().save();
            Application.Quit();
        }
        else if (type == ButtonType.Reset)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Title");
        }

        else
            return;
    }
}
