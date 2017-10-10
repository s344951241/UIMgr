using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class UIManager{

    private static UIManager _instance;
    public static UIManager Instance {
        get {
            if (_instance == null)
                _instance = new UIManager();
            return _instance;
        }
    }
    private Transform _canvasTransform;
    public Transform CanvasTransform
    {
        get
        {
            if (_canvasTransform == null)
            {
                _canvasTransform = GameObject.Find("Canvas").transform;
            }
            return _canvasTransform;
        }
    }
    private int _panelCount;
    private Dictionary<UIPanelType, PanelInfo> _panelPathDic;//存储所有的面板信息
    private Dictionary<UIPanelType, BasePanel> _panelDic;//保存basePanel
    private List<BasePanel> _panelList;
    private UIManager()
    {
        ParseUIPanelTypeJson();
    }
    /// <summary>
    /// 加载界面
    /// </summary>
    public void InitPanel(UIPanelType panelType)
    {
        if (_panelList == null)
            _panelList = new List<BasePanel>();
        //判断栈里面是否有页面
        if (_panelList.Count > 0)
        {
            foreach (var pa in _panelList)
            {
                pa.OnPause();
                if (!_panelPathDic[panelType].isPop)
                {
                    pa.setFalse();
                }
            }
        }
        BasePanel panel = GetPanel(panelType);
        panel.OnEnter();
        _panelList.Add(panel);
    }
    /// <summary>
    /// 页面关闭
    /// </summary>
    public void ClosePanel(BasePanel panel)
    {
        if (_panelList == null)
            _panelList = new List<BasePanel>();
        if (_panelList.Count <= 0)
            return;
        if (!_panelList.Contains(panel))
            return;
        _panelList.Remove(panel);
        panel.OnExit();

        if (_panelList.Count <= 0)
            return;
        BasePanel topPanel2 = _panelList[_panelList.Count-1];
        topPanel2.OnResume();
    }

    public void ClosePanel(UIPanelType type)
    {
        if (_panelDic.ContainsKey(type))
        {
            ClosePanel(_panelDic[type]);
        }
    }
    /// <summary>
    /// 根据面板类型得到实例化面板
    /// </summary>
    /// <returns></returns>
    private BasePanel GetPanel(UIPanelType panelType)
    {
        if (_panelDic == null)
        {
            _panelDic = new Dictionary<UIPanelType, BasePanel>();
        }
        BasePanel panel = _panelDic.TryGet(panelType);
        if (panel == null)
        {
            PanelInfo info = _panelPathDic.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(info.path),CanvasTransform,false) as GameObject;
            instPanel.name =  instPanel.name.Replace("(Clone)", "");
            if (instPanel.GetComponent<CanvasGroup>() == null)
                instPanel.AddComponent<CanvasGroup>();
            // instPanel.transform.SetParent(CanvasTransform, false);
            //BasePanel p = (BasePanel)Assembly.Load(info.className).CreateInstance(info.className);
            Assembly assem = Assembly.GetAssembly(typeof(BasePanel));

            foreach (Type tChild in assem.GetTypes())
            {

                if (tChild.Name.Equals(info.className))
                {
                    object[] param = new object[1];
                    param[0] = instPanel;
                    tChild.GetMethod("Init").Invoke(this, param);
                }
                
            }
            _panelDic.Add(panelType, instPanel.GetComponent<BasePanel>());
            panel = instPanel.GetComponent<BasePanel>();
            panel.OnInit();
        }
        return panel;
    }
    [Serializable]
    class UIPanelTypeJson
    {
        public List<PanelInfo> infoList;
    }
    private void ParseUIPanelTypeJson()
    {
        _panelPathDic = new Dictionary<UIPanelType, PanelInfo>(); 
        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");
        UIPanelTypeJson json = JsonUtility.FromJson<UIPanelTypeJson> (ta.text);

        foreach (PanelInfo info in json.infoList)
        {
            _panelPathDic.Add(info.panelType, info);
        }
    }
}


