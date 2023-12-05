using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupLose : BasePopup
{
    public Button btnRestart;
    public TMP_Text textScore;
    public TMP_Text textBestScore;

    public void UpdateTextScore(int score)
    {
        textScore.text = score.ToString();
    }
    public void UpdateTextBestScore(int bestScore)
    {
        textBestScore.text = bestScore.ToString();
    }

    private void OnEnable()
    {
        btnRestart.onClick.AddListener(OnClickRestart);
    }
    private void OnDisable()
    {
        btnRestart.onClick.RemoveListener(OnClickRestart);   
    }

    public void OnClickRestart()
    {
        GameController.instance.RestartGame();
    }
}
