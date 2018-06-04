using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using TMPro;

public class testFirebaseConx : MonoBehaviour {

	private TextMeshProUGUI textMesh;
	private string title;

	// Use this for initialization
	public void Start () {

		textMesh = GetComponent<TextMeshProUGUI>();
		title = "";

        // Set this before calling into the realtime database
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://um6p-tour.firebaseio.com");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

	}
	
	/* void HandleValueChanged(object sender, ValueChangedEventArgs args) {
		if (args.DatabaseError != null) {
			Debug.LogError(args.DatabaseError.Message);
		}
		var livingRoomItems = args.Snapshot.Value as Dictionary<string, object>;
		foreach (var item in livingRoomItems) {
			Debug.Log(">> " + item.Key);
			var values = item.Value as Dictionary<string, object>;
			foreach (var v in values) {
				Debug.Log(v.Key + " : " + v.Value);
			}
		}
	} */

	// Update is called once per frame
	void Update () {
		textMesh.text = title; 
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
							if (v.Key == "title") {
								title = "> " + v.Value.ToString();
							}
						}
					}

				}
			});
	}
}
