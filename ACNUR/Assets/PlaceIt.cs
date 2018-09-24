using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceIt : MonoBehaviour {

	public InputManager inputManager;
	public GameObject panel;
	public RawImage rawImage;
	public MapController mapController;
	public GameObject button;
	MapSlot mapSlot;
	public bool isOn;
	bool dragging;

	public void Init() {		
		mapSlot = mapController.AddUser (Data.Instance.userDataActive);
		mapSlot.transform.localPosition = new Vector3(1000,1000,0);
		button.SetActive(false);
		panel.SetActive (true);
		rawImage.texture = Data.Instance.photo;
		Invoke("Delayed", 0.1f);		
	}
	void Delayed()
	{
		isOn = true;
	}
	public void OnButtonDown()
	{
		isOn = false;
	}
	void Update()
	{
		if(!isOn)
			return;
		if(Input.GetMouseButtonDown(0))
		{	
			Invoke("ClickDelayed", 0.1f);	
		} else if(Input.GetMouseButtonUp(0))
		{
			dragging = false;
			button.SetActive(true);
			Data.Instance.userDataActive.coordsOrigen = inputManager.pos;	
		} else if(dragging)
		{
			mapSlot.transform.localPosition = inputManager.pos;			
		}	
	}
	void ClickDelayed()
	{
		if(isOn)
			dragging = true;
	}
	public void Done()
	{
		isOn = false;
		GetComponent<UI> ().Next ();
	}

}
