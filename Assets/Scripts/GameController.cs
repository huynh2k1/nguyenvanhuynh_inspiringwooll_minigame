using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public StateGame state;

    public float timeDie;
    private void Awake()
    {
        instance = this;
        timeDie = 15f;
    }

    private void Start()
    {
        state = StateGame.Home;
    }

    public void GameOver()
    {
        PopupController.instance.ShowPopupLose(true);
        state = StateGame.End;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
public enum StateGame{
    Home,
    Playing,
    End
}
