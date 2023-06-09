using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class Utils : MonoBehaviour
{
    public static TextMeshProUGUI GetTextObj(string gameObjectName)
    {
        return GameObject.Find(gameObjectName).GetComponent<TextMeshProUGUI>();
    }

    public static string FormatNumber(int number)
    {
        if (number < 1000)
        {
            return number.ToString();
        }

        string formatted = "", str = number.ToString();
        for (int i = 1, n = str.Length; i <= n; i++)
        {
            formatted += str[str.Length - i];
            if (i + 1 <= n && i % 3 == 0)
            {
                formatted += ",";
            }
        }

        char[] charArr = formatted.ToCharArray();
        Array.Reverse(charArr);

        return new string(charArr);
    }
}
