using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;
using Lean.Touch;

public class AddComponent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DeleteScale() {
		Destroy(GetComponent("LeanScale"));
	}

	public void CreateScale() {
		LeanScale ls = gameObject.AddComponent<LeanScale>() as LeanScale;
	}
}
