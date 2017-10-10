using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemPanel : BasePanel {

    public static void Init(GameObject obj)
    {
        obj.AddComponent<SystemPanel>();
    }

    public override void OnInit()
    {
        base.OnInit();
        _root.transform.Find("Close").GetComponent<Button>().onClick.AddListener(delegate
        {
            UIManager.Instance.ClosePanel(this);
        });
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnResume()
    {
        base.OnResume();
    }
    public override void OnPause()
    {
        base.OnPause();
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
