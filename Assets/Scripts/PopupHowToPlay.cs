using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupHowToPlay : BasePopup
{
    public Button btnClose;
    private void OnEnable()
    {
        btnClose.onClick.AddListener(OnClickClose);
    }
    private void OnDisable()
    {
        btnClose.onClick.RemoveListener(OnClickClose);
    }
    private void OnClickClose()
    {
        Show(false);
    }
}
