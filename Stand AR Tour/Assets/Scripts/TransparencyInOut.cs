using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparencyInOut : MonoBehaviour {

    private CanvasGroup canvasGroup;

    public CanvasGroup websiteCanvasGroup;

    public Button button;
    public Button button1;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Update()
    {
        
    }

    public void ChangeAlpha() {
        canvasGroup.alpha = 1;
        websiteCanvasGroup.alpha = 0.6f;
        button.interactable = true;
        button.gameObject.SetActive(true);
        if(button1.interactable == true) {
            button1.interactable = false;
            button1.gameObject.SetActive(false);
        } else {
            button1.interactable = true;
        }
    }
}