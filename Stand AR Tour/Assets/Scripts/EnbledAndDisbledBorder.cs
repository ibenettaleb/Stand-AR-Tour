using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnbledAndDisbledBorder : MonoBehaviour {

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
    }

}
