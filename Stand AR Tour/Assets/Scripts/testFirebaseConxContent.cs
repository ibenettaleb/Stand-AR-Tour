using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using TMPro;

public class testFirebaseConxContent : MonoBehaviour {

	private TextMeshProUGUI textMesh;
	private string content;

	// Use this for initialization
	public void Start () {

		textMesh = GetComponent<TextMeshProUGUI>();
		content = "";

        // Set this before calling into the realtime database
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://um6p-tour.firebaseio.com");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

	}

	// Update is called once per frame
	void Update () {
		textMesh.text = content;
		
		FirebaseDatabase.DefaultInstance
			.GetReference("users")
			.GetValueAsync().ContinueWith(task => {
				if(task.IsFaulted) {
					Debug.Log("Error ...");
				}
				else if (task.IsCompleted) {
					DataSnapshot snapshot = task.Result;
					var users = snapshot.Value as Dictionary<string, object>;
					foreach (var user in users) {
						var values = user.Value as Dictionary<string, object>;
						foreach (var v in values) {
							if (v.Key == "content") {
								content = "> " + v.Value.ToString();
							}
						}
					}

				}
			});
	}
}
