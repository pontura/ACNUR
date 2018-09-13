using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePanel : MonoBehaviour {
	
	public GameObject panel;
	public InputField inputField;

	public void Init() {
		panel.SetActive (true);
		inputField.text = "";
	}
	public void Done()
	{
		//if(inputField.text.Length>0)
			GetComponent<UI> ().Next ();
	}
}
