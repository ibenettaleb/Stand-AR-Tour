using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class ChangeImage : MonoBehaviour {


	RawImage m_RawImage;
    //Select a Texture in the Inspector to change to

	// Use this for initialization
	void Start () {

		//Fetch the RawImage component from the GameObject
        m_RawImage = GetComponent<RawImage>();

		string url;

        // Set this before calling into the realtime database
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://um6p-tour.firebaseio.com");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

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
							if (v.Key == "url") {
								url = v.Value.ToString();
								StartCoroutine(LoadImg(url));
							}
						}
					}

				}
			});
	}

	IEnumerator LoadImg(string url) {
		yield return 0;
		WWW imgLink = new WWW(url);
		yield return imgLink;
		//Change the Texture to be the one you define in the Inspector
        m_RawImage.texture = imgLink.texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
