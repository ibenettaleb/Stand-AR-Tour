using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using System.Net;

public class WorldSpaceVideo : MonoBehaviour {

	public Material playButtonMaterial;
	public Material pauseButtonMaterial;
	public Renderer playButtonRenderer;
	public VideoClip[] videoClips;

	public TextMeshProUGUI currentMinutes;
	public TextMeshProUGUI currentSeconds;
	public TextMeshProUGUI totalMinutes;
	public TextMeshProUGUI totalSeconds;

	public PlayHeadMover playHeadMover;
	

	private VideoPlayer videoPlayer;

	private VideoSource videoSource;
	private float videoDuration;

	void Awake()
	{
		videoPlayer = GetComponent<VideoPlayer> ();
	}

	// Use this for initialization
	void Start () {
		videoPlayer.targetTexture.Release();
		// videoPlayer.clip = videoClips[0];
		videoPlayer.source = VideoSource.VideoClip;
		videoPlayer.source = VideoSource.Url;
		videoPlayer.url = "http://10.24.28.35:3000/1.MP4";

        //Set video To Play then prepare Audio to prevent Buffering
        // videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        //Play Video
        videoPlayer.Play();
		playButtonRenderer.material = pauseButtonMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		if (videoPlayer.isPlaying) {
			SetCurrentTimeUI();
			// playHeadMover.MovePlayhead (CalculatePlayedFraction ());
		}
	}

	public int videoClipIndex = 1;
	public void SetNextClip() {

		videoClipIndex = videoClipIndex + 1;
		Debug.Log(videoClipIndex);
		StartCoroutine(Request("http://10.24.28.35:3000/" + videoClipIndex + ".MP4"));

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
			//Set video To Play then prepare Audio to prevent Buffering
			// videoPlayer.clip = videoToPlay;
			videoPlayer.Prepare();

			//Play Video
			videoPlayer.Play();
			playButtonRenderer.material = pauseButtonMaterial;

		} else {
			videoClipIndex = 1;
			videoPlayer.url = "http://10.24.28.35:3000/" + videoClipIndex + ".MP4";
			//Set video To Play then prepare Audio to prevent Buffering
			// videoPlayer.clip = videoToPlay;
			videoPlayer.Prepare();

			//Play Video
			videoPlayer.Play();
			playButtonRenderer.material = pauseButtonMaterial;
		} 
	}

	public void PlayPause() {
		Debug.Log("Start Video");
		if (videoPlayer.isPlaying) {
			videoPlayer.Pause();
			playButtonRenderer.material = playButtonMaterial;
		} else {
			videoPlayer.Play();
			// SetTotalTimeUI();
			playButtonRenderer.material = pauseButtonMaterial;
		}
	}

	void SetCurrentTimeUI() {
		string minutes = Mathf.Floor ((int)videoPlayer.time / 60).ToString ("00");
		string seconds = ((int)videoPlayer.time % 60).ToString("00");

		currentMinutes.text = minutes;
		currentSeconds.text = seconds;
	}

	/* void SetTotalTimeUI() {
		string minutes = Mathf.Floor ((int)videoPlayer.clip.length / 60).ToString ("00");
		string seconds = ((int)videoPlayer.clip.length % 60).ToString("00");

		totalMinutes.text = minutes;
		totalSeconds.text = seconds;
	}

	double CalculatePlayedFraction() {
		double fraction = (double) videoPlayer.frame / (double) videoPlayer.clip.frameCount;
		return fraction;
	}*/

}
