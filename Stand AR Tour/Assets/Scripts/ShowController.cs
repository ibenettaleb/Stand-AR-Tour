using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowController : MonoBehaviour {
   
    void Start()
    {
        gameObject.SetActive(true);
    }
    void Update()
    {
        
    }

    public void ShowInfo() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
        Invoke("Start", 5.0f);
    }
}