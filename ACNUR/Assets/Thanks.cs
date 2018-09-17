using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thanks : MonoBehaviour {

	public GameObject panel;

	public void Init() {
		panel.SetActive (true);
	}

	public void Done()
	{
		GetComponent<UI> ().Reset ();
	}
}
