using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Service {
	public string serviceTitle;
	public string serviceDescription;
	public Sprite icon;
}

public class ServiceScrollList : MonoBehaviour {

	public List<Service> serviceList;
	public Transform contentPanel;
	public SimpleObjectPool buttonObjectPool;

	// Use this for initialization
	void Start () {
		RefreshDisplay();
	}

	public void RefreshDisplay()
	{
		AddButtons();
	}
	
	private void AddButtons() {
		for (int i = 0; i < serviceList.Count; i++) {
			Service service = serviceList[i];
			GameObject newButton = buttonObjectPool.GetObject ();
			newButton.transform.SetParent(contentPanel);

			SampleButton sampleButton = newButton.GetComponent<SampleButton>();
			sampleButton.Setup(service, this);

		}
	}

}
