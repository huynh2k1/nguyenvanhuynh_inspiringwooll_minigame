using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefData : MonoBehaviour
{
    public static int HighScore
    {
        get => PlayerPrefs.GetInt("Best_Score", 0);
        set
        {
            PlayerPrefs.SetInt("Best_Score", value);
        }

    }
}
