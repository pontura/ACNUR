using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thanks : MonoBehaviour {

	public GameObject panel;

	public void Init() {
		Data.Instance.serverController.Save ();
		panel.SetActive (true);
	}
	public void Done()
	{
		GetComponent<UI> ().Reset ();
	}
}
