using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

	public PhotoCapture photoPanel;
	public NamePanel namePanel;
	public PlaceIt placeItPanel;
	int id;

	void Start()
	{
		ResetPanels ();
		Next ();
	}
	void ResetPanels()
	{
		namePanel.panel.SetActive (false);
		photoPanel.panel.SetActive (false);
		placeItPanel.panel.SetActive (false);
	}
	public void Next()
	{
		id++;
		OpenPanel (id);
	}
	public void OpenPanel(int id)
	{
		ResetPanels ();

		switch (id) {
		case 1:
			namePanel.Init ();
			break;
		case 2:
			photoPanel.Init ();
			break;
		case 3:
			placeItPanel.Init ();
			break;
		}
	}
}
