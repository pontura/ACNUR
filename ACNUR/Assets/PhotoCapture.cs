using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;


public class PhotoCapture : MonoBehaviour 
{
	public GameObject panel;

	WebCamTexture webCamTexture;
	public RawImage image; 

	public void Init() {
		panel.SetActive (true);
		webCamTexture = new WebCamTexture();
		webCamTexture.Play();
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
		Data.Instance.photo.SetPixels(webCamTexture.GetPixels());
		Data.Instance.photo.Apply();
		GetComponent<UI> ().Next ();
		webCamTexture.Stop();
		//System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
	}
}