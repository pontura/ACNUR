﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDest : MonoBehaviour {

	public InputManager inputManager;
	public GameObject panel;
	public MapController mapController;
	MapSlot mapSlot;
	public bool isOn;
	bool dragging;	
	public GameObject title;
	public GameObject subtitle;
	public GameObject buttonDone;

	public void Init() {
		dragging = false;
		isOn = false;
		mapSlot = mapController.AddUser (Data.Instance.userDataActive);
		mapSlot.transform.localPosition = new Vector3(1000,1000,0);
		title.SetActive(true);
		buttonDone.SetActive(false);	
		subtitle.SetActive(false);	
		panel.SetActive (true);
		Invoke("Delayed", 0.2f);	
	}
	void Delayed()
	{
		isOn = true;
	}
	
	public void Done()
	{		
		title.SetActive(false);		
		mapController.Reset ();
		mapController.AddUser (Data.Instance.userDataActive);	
	}
	bool ended;
	public void OnButtonDown()
	{
		buttonDone.SetActive(false);
		if(ended)
		{
			ended = false;
			dragging = false;
			GetComponent<ZonasManager>().ResetAll();
			GetComponent<UI> ().Next ();
			return;
		}

		ended = true;
		isOn = false;
		Invoke("DelayToEnd", 3);
		Done();
	}
	void DelayToEnd()
	{
		buttonDone.SetActive(true);
		GetComponent<ZonasManager>().SetArea();	
		subtitle.SetActive(true);		
	}
	void Update()
	{
		if(!isOn)
			return;
		if(Input.GetMouseButtonDown(0))
		{	
			Invoke("ClickDelayed", 0.1f);	
		}
		else if(Input.GetMouseButtonUp(0))
		{
			dragging = false;
			buttonDone.SetActive(true);	
			Data.Instance.userDataActive.coordsDestino = inputManager.pos;	
			mapSlot.transform.localPosition = inputManager.pos;	
		}
		else if(dragging)
			mapSlot.transform.localPosition = inputManager.pos;
	}
	void ClickDelayed()
	{
		if(isOn)
			dragging = true;
	}
}
