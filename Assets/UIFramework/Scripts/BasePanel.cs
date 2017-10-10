using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour {

    protected CanvasGroup _canvasGroup;
    protected GameObject _root;
    protected bool _isActive;
    /// <summary>
    /// 初始化界面
    /// </summary>
    public virtual void OnInit()
    {
        if (_canvasGroup == null)
            _canvasGroup = GetComponent<CanvasGroup>();
        _root = gameObject;
    }
    /// <summary>
    /// 界面显示
    /// </summary>
    public virtual void OnEnter()
    {
        _root.SetActive(true);
        _isActive = true;
        _root.transform.SetAsLastSibling();
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }
    /// <summary>
    /// 界面暂停
    /// </summary>
    public virtual void OnPause()
    {
        _canvasGroup.blocksRaycasts = false;
    }
    /// <summary>
    ///界面继续
    /// </summary>
    public virtual void OnResume()
    {
        _canvasGroup.blocksRaycasts = true;
        setTrue();
        _root.transform.SetAsLastSibling();
    }

    public void setFalse()
    {
        if (_isActive)
        {
            _root.SetActive(false);
            _isActive = false;
        }
    }

    private void setTrue()
    {
        if (!_isActive)
        {
            _root.SetActive(true);
            _isActive = true;
        }
    }
    /// <summary>
    /// 界面退出
    /// </summary>
    public virtual void OnExit()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _root.SetActive(false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
