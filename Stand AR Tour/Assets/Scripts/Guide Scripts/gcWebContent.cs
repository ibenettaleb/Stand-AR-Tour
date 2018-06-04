using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gcWebContent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowInfo() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    } 
}
