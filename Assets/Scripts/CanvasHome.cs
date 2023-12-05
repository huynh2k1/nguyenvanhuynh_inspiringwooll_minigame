using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHome : MonoBehaviour
{
    public static CanvasHome instance;
    public Button btnPlay;
    public Button btnHowToPlay;

    private void Awake()
    {
        instance = this;
    }
    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
    private void OnEnable()
    {
        btnPlay.onClick.AddListener(OnClickPlay);
        btnHowToPlay.onClick.AddListener(OnClickHowToPlay);
    }
    private void OnDisable()
    {
        btnPlay.onClick.RemoveListener(OnClickPlay);
        btnHowToPlay.onClick.RemoveListener(OnClickHowToPlay);
    }
    private void OnClickPlay()
    {
        CanvasController.instance.ShowCanvasHome(false);
        CanvasController.instance.ShowCanvasGame(true);
        GameController.instance.state = StateGame.Playing;
        SpawnController.instance.Init();
    }
    private void OnClickHowToPlay()
    {
        PopupController.instance.ShowPopupHowToPlay(true);
    }
}
