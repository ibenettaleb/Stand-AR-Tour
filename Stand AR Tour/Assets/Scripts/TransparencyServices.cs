using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparencyServices : MonoBehaviour {

	// Use this for initialization
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
        websiteCanvasGroup.alpha = 0.7f;
        if(button.interactable == true) {
            button.interactable = false;
            button.gameObject.SetActive(false);
        } else {
            button.interactable = true;
        }
        button1.interactable = true;
        button1.gameObject.SetActive(true);
    }
}
