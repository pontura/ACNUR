﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour {

	public GameObject app;
	public GameObject fullScreenApp;

	public GameObject background;
	public Splash splash;
	public PhotoCapture photoPanel;
	public NamePanel namePanel;
	public PlaceIt placeItPanel;
	public ChooseDest chooseDestPanel;
	public Thanks thanksPanel;
	public MapController mapController;
	public Text field;
	public GameObject contador;

	int id;
	void Awake()
	{
		app.SetActive (false);
		fullScreenApp.SetActive (false);

		if (Data.Instance.build == Data.builds.APP)
			app.SetActive (true);
		else
			fullScreenApp.SetActive (true);
	}
	void Start()
	{
		
		ResetPanels ();
		Next ();
	}
	void ResetPanels()
	{
		splash.panel.SetActive (false);
		chooseDestPanel.panel.SetActive (false);
		namePanel.panel.SetActive (false);
		photoPanel.panel.SetActive (false);
		placeItPanel.panel.SetActive (false);
		thanksPanel.panel.SetActive (false);
	}
	public void Reset()
	{
		mapController.Reset ();
		Data.Instance.Reset ();	
		id = 0;	
		Next ();
		
	}
	public void Next()
	{	
		print("Next " + id);	
		OpenPanel (id);
		id++;
	}
	public void OpenPanel(int id)
	{
		ResetPanels ();

		switch (id) {
		case 0:
			background.SetActive (true);
			splash.Init ();
			SetText(1);
			break;
	//	case 1:
		//	background.SetActive (true);
		//	namePanel.Init ();
		//	SetText(1);
		//	break;
		case 1:
			background.SetActive (true);
			photoPanel.Init ();
			SetText(2);
			break;
		case 2:
			background.SetActive (false);
			placeItPanel.Init ();
			SetText(3);
			break;
		case 3:
			background.SetActive (false);
			chooseDestPanel.Init ();
			SetText(4);
			break;
		case 4:
			background.SetActive (true);
			thanksPanel.Init ();
			SetText(0);
			break;
		}
	}
	public void SetText(int num)
	{
		// if(num==0)
		// 	contador.SetActive (false);
		// else
		// 	contador.SetActive (true);
		//field.text = num + "/4";
	}
	
}
