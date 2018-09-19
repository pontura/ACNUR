using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour {

	public GameObject panel;
	public Sprite[] all;
	public Image image;
	int id;

	public void Init() {
		panel.SetActive (true);
	}
	public void Loop()
	{
		if(id>all.Length-1)
			id = 0;
		image.sprite = all[id];
		Invoke ("Loop", 2);
		id++;
	}
	public void Done()
	{
		GetComponent<UI> ().Next ();
	}
}
