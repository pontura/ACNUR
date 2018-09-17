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
		Data.Instance.userDataActive.username = inputField.text;
		GetComponent<UI> ().Next ();
	}
}
