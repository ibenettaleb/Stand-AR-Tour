using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gCardZoomOut : MonoBehaviour {

	void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        
    }

    public void ShowInfo() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }
}
