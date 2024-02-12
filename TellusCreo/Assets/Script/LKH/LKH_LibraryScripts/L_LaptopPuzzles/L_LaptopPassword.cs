using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_LaptopPassword : MonoBehaviour
{
    private static string correctPW = "7359";

    private enum PadType { Number, Back, Enter }
    [SerializeField] private PadType type;
    [SerializeField] private int number;

    private static int count;
    private static string password;
    [SerializeField] private Text numText;


    private void OnEnable()
    {
        ResetPassword();
    }

    private bool IsRightPassword()
    {
        if (password.StartsWith(correctPW))
            return true;
        return false;
    }

    private void ResetPassword()
    {
        password = "";
        count = 0;

        TextUpdate();
    }

    private void TextUpdate()
    {
        numText.text = password;
    }

    private void OnMouseUp()
    {
        switch (type)
        {
            case PadType.Number:
                if (count >= 4) return;
                password += number.ToString();
                TextUpdate();
                ++count;
                break;

            case PadType.Back:
                if (count <= 0) return;
                --count;
                string copy = "";
                for (int i =0; i<count; i++)
                    copy += password[i];
                password = "";
                password = copy;
                TextUpdate();
                break;

            case PadType.Enter:
                if (count == 4)
                    if (IsRightPassword())
                        L_GameManager.instance.Set_laptopLocked();
                ResetPassword();
                break;
        }
    }
}
