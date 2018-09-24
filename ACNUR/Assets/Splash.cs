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
		Loop();
		panel.SetActive (true);
	}
	public void Loop()
	{
		Invoke ("Loop", 3);

		if(id>all.Length-1)
			id = 0;
		image.sprite = all[id];		
		id++;
	}
	public void Done()
	{
		CancelInvoke("Loop");
		GetComponent<UI> ().Next ();
	}
}
