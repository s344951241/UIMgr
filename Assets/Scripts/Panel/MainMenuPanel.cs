using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel :BasePanel {

    public static void Init(GameObject obj)
    {
        obj.AddComponent<MainMenuPanel>();
    }

    public override void OnInit()
    {
        base.OnInit();
        transform.Find("Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            UIManager.Instance.InitPanel(UIPanelType.System);
        });
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
    public override void OnExit()
    {
        base.OnExit();
       
    }

    public override void OnResume()
    {
        base.OnResume();
    }
    public override void OnPause()
    {
        base.OnPause();
    }
}
