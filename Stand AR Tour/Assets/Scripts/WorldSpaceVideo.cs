using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using System.Net;

public class WorldSpaceVideo : MonoBehaviour {

	public Sprite playButton;
	public Sprite pauseButton;
	public Renderer playButtonRenderer;

	public TextMeshProUGUI currentMinutes;
	public TextMeshProUGUI currentSeconds;
	

	private VideoPlayer videoPlayer;

	private VideoSource videoSource;
	private float videoDuration;

	public LoadingCircle loadingCircle;

	void Awake()
	{
		videoPlayer = GetComponent<VideoPlayer> ();
		loadingCircle = FindObjectOfType(typeof(LoadingCircle)) as LoadingCircle;
	}

	// Use this for initialization
	void Start () {
		loadingCircle.SetActiveTrue();
		videoPlayer.targetTexture.Release();
		videoPlayer.source = VideoSource.VideoClip;
		videoPlayer.source = VideoSource.Url;
		videoPlayer.url = "http://10.24.28.35:3000/1.MP4";

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.Prepare();

        //Play Video
        videoPlayer.Play();
		loadingCircle.SetActiveFalse();
		
		// playButtonRenderer.material = pauseButtonMaterial;
		playButton = pauseButton;
	}
	
	// Update is called once per frame
	void Update () {
		if (videoPlayer.isPlaying) {
			SetCurrentTimeUI();
		}
	}

	public int videoClipIndex = 1;

    public void SetNextClip() {
		loadingCircle.SetActiveTrue();
		videoClipIndex = videoClipIndex + 1;
		Debug.Log(videoClipIndex);
		StartCoroutine(Request("http://10.24.28.35:3000/" + videoClipIndex + ".MP4"));
		loadingCircle.SetActiveFalse();
	}

	IEnumerator Request(string url) {

		Debug.Log(url);

		WWW www = new WWW (url);
		yield return www;

		string html = www.text;
		string title = "";

		string[] htmlList = html.Split ('\n');
		for (int i = 0; i < htmlList.Length; i++) {
			if (htmlList[i].ToString().Contains("title")) {
				title = htmlList[i].Replace ("<title>", "");
				title = title.Replace ("</title>", "");
				Debug.Log(title);
				break;
			}
		}

		if (title == "") {
			videoPlayer.url = "http://10.24.28.35:3000/" + videoClipIndex + ".MP4";
			videoPlayer.Prepare();

			//Play Video
			videoPlayer.Play();
			// playButtonRenderer.material = pauseButtonMaterial;

		} else {
			videoClipIndex = 1;
			videoPlayer.url = "http://10.24.28.35:3000/" + videoClipIndex + ".MP4";
			videoPlayer.Prepare();

			//Play Video
			videoPlayer.Play();
			// playButtonRenderer.material = pauseButtonMaterial;
		} 
	}

	public void PlayPause() {
		Debug.Log("Start Video");
		if (videoPlayer.isPlaying) {
			videoPlayer.Pause();
			// playButtonRenderer.material = playButtonMaterial;
		} else {
			videoPlayer.Play();
			// playButtonRenderer.material = pauseButtonMaterial;
		}
	}

	void SetCurrentTimeUI() {
		string minutes = Mathf.Floor ((int)videoPlayer.time / 60).ToString ("00");
		string seconds = ((int)videoPlayer.time % 60).ToString("00");

		currentMinutes.text = minutes;
		currentSeconds.text = seconds;
	}

}
