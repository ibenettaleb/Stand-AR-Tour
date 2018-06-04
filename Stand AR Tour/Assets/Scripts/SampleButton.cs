using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SampleButton : MonoBehaviour {

	public Button button;
	public TextMeshProUGUI title;
	public TextMeshProUGUI description;
	public Image iconImage;

	private Service service;
	private ServiceScrollList scrollList;

	// Use this for initialization
	void Start () {
		Debug.Log("Hello From GitHub");
	}

	public void Setup(Service currentService, ServiceScrollList currentScrollList) {
		service = currentService;
		title.text = service.serviceTitle;
		description.text = service.serviceDescription;
		iconImage.sprite = service.icon;

		scrollList = currentScrollList;
	}
	
}
