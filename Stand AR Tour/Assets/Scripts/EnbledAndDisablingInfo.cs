using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnbledAndDisablingInfo : MonoBehaviour {

	private RawImage imgInfo;

	// Use this for initialization
	void Start () {
        imgInfo = GetComponent<RawImage>();
        imgInfo.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowInfo() {
        imgInfo = GetComponent<RawImage>();
        imgInfo.enabled = true;
        Invoke("Start", 5.0f);
        Debug.Log("After 3s");
    }
}
