using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartApp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.Instance.InitPanel(UIPanelType.MainMenu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
