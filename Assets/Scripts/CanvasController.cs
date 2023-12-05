using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ShowCanvasHome(true);
        ShowCanvasGame(false);
    }

    public void ShowCanvasHome(bool isShow)
    {
        CanvasHome.instance.Show(isShow);
    }
    public void ShowCanvasGame(bool isShow)
    {
        CanvasGame.instance.Show(isShow);
    }
    
}
