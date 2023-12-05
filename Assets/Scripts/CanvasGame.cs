using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGame : MonoBehaviour
{
    public static CanvasGame instance;

    public List<GameObject> healthList;
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public Button btnRestart;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        btnRestart.onClick.AddListener(OnClickRestart);
    }
    private void OnDisable()
    {
        btnRestart.onClick.RemoveAllListeners();
    }
    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
    public void UpdateTimeText(int time)
    {
        timeText.text = time.ToString() + "s";
    }
    private void OnClickRestart()
    {
        GameController.instance.RestartGame();
    }

    public void UpdateIconHealth(int hp)
    {
        for(int i = 0; i <= hp; i++)
        {
            healthList[i].SetActive(true);
        }
        for(int i = hp + 1; i < healthList.Count; i++)
        {
            healthList[i].SetActive(false);
        }
    }
}
