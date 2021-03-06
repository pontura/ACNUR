﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;


public class PhotoCapture : MonoBehaviour 
{
	public GameObject panel;

	WebCamTexture webCamTexture;
	public RawImage image; 
	public Text countdownField; 

	public void Init() {
		num= 3;
		panel.SetActive (true);
		int totalDevices = WebCamTexture.devices.Length;
		webCamTexture = new WebCamTexture(WebCamTexture.devices[totalDevices-1].name);
		webCamTexture.Play();
		countdownField.text = "";
		clicked = false;
	}
	bool clicked;
	public void Clicked()
	{
		if(clicked)
		return;
		clicked = true;
		Loop();
	}
	int num;
	void Loop()
	{
		countdownField.text = num.ToString();
		if (num==0)
		{
			 Done();
			 return;
		}
		Invoke("Loop", 1);
		num--;
	}

	void Update()
	{
		image.texture = webCamTexture;
	}

	WebCamTexture _CamTex;
	//private string _SavePath = "C:/WebcamSnaps/";

	public void Done()
	{
		Data.Instance.photo = new Texture2D(webCamTexture.width, webCamTexture.height);
		Data.Instance.userDataActive.texture = Data.Instance.photo;
		Data.Instance.photo.SetPixels(webCamTexture.GetPixels());
		Data.Instance.photo.Apply();		
		webCamTexture.Stop();		
		GetComponent<UI> ().Next ();
		//System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
	}
}