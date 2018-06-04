using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnbledAndDisbledInfo : MonoBehaviour {

    public Animation anim;

	void Start()
    {
        anim = GetComponent<Animation>();
        gameObject.SetActive(true);
    }
    void Update()
    {
        Invoke("stopAnimation", 7.0f);
    }

    public void ShowInfo() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void stopAnimation() {
        anim.Stop();
    }
}
