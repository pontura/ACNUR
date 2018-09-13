using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceIt : MonoBehaviour {

	public GameObject panel;
	public RawImage rawImage;

	public void Init() {
		panel.SetActive (true);
		rawImage.texture = Data.Instance.photo;
	}
	
	public void Done()
	{
		
	}
}
