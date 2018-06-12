using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCircle : MonoBehaviour {

	private RectTransform rectComponent;
	private float rotateSpeed = 200f;

	// Use this for initialization
	void Start () {
		rectComponent = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		rectComponent.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
	}

	public void SetActiveTrue() {
		transform.parent.gameObject.SetActive(true);
	}
	public void SetActiveFalse() {
		transform.parent.gameObject.SetActive(false);
	}

	public void Show() {
		Debug.Log("Showing, LoadingCircle Class");
	}

}
