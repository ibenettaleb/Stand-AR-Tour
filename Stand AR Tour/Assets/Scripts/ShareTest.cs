using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ShareTest : MonoBehaviour {

	NativeShare ns = new NativeShare();

	// Use this for initialization
	void Start () {
		// DeletePath();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Share(string url) {
		StartCoroutine(DownloadAndShare(url));
	}

	private IEnumerator TakeSanpShotAndShare() {

		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
		File.WriteAllBytes( filePath, ss.EncodeToPNG() );

		Destroy(ss);

		ns.AddFile(filePath).SetSubject("Shared File").SetText("Hello From Unity");
		ns.Share();
	}

	private IEnumerator TakePDFAndShare() {
		yield return new WaitForEndOfFrame();

		string dbPath = "";

		if (Application.platform == RuntimePlatform.Android)
		{
			// Android
			string oriPath = Path.Combine(Application.streamingAssetsPath, "content.pdf");
			
			// Android only use WWW to read file
			WWW reader = new WWW(oriPath);
			while ( ! reader.isDone) {}
			
			string realPath = Application.persistentDataPath + "/content.pdf";
			File.WriteAllBytes(realPath, reader.bytes);

			ns.AddFile(realPath).SetSubject("Shared File").SetText("Hello From Unity");
			ns.Share();
			
			dbPath = realPath;
		}
		else
		{
			// iOS
			dbPath = Path.Combine(Application.streamingAssetsPath, "content.pdf");
		}
	}

	private IEnumerator DownloadAndShare(string url) {
		var uwr = new UnityWebRequest( url, UnityWebRequest.kHttpVerbGET );
		string path = Path.Combine( Application.temporaryCachePath, "temp.pdf" );
		uwr.downloadHandler = new DownloadHandlerFile( path );

		yield return uwr.SendWebRequest();

		if ( uwr.isNetworkError || uwr.isHttpError )
			Debug.LogError( uwr.error );
		else
			new NativeShare().AddFile(path).Share();
	}

	private void DeletePath() {
		string path = Path.Combine( Application.temporaryCachePath, "temp.pdf" );
		File.Delete(path);
	}
}
