using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public static PopupController instance;
    [Header("____Popups____")]
    public PopupLose losePopup;
    public PopupHowToPlay howToPlayPopup;

    private void Awake()
    {
        instance = this;
    }

    public void ShowPopupLose(bool isShow)
    {
        losePopup.Show(isShow);
    }
    public void ShowPopupHowToPlay(bool isShow)
    {
        howToPlayPopup.Show(isShow);
    }
    public void UpdateLosePopup(int score)
    {
        losePopup.UpdateTextScore(score);
        if(score > PrefData.HighScore)
        {
            PrefData.HighScore = score;
            losePopup.UpdateTextBestScore(score);
        }
        else
        {
            losePopup.UpdateTextBestScore(PrefData.HighScore);
        }
    }
}
