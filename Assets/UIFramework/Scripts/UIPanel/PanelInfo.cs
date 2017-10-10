using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PanelInfo:ISerializationCallbackReceiver{
    [NonSerialized]
    public UIPanelType panelType;
    public string panelTypeString;
    public string path;
    public string className;
    public bool isPop;

    //序列化
    public void OnBeforeSerialize()
    {
        //panelTypeString = panelType.ToString();
    }
    //反序列化
    public void OnAfterDeserialize()
    {
        UIPanelType type = (UIPanelType)System.Enum.Parse(typeof(UIPanelType),panelTypeString);
        panelType = type;

    }
}
