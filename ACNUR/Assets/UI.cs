using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

	public GameObject app;
	public GameObject fullScreenApp;

	public PhotoCapture photoPanel;
	public NamePanel namePanel;
	public PlaceIt placeItPanel;
	public ChooseDest chooseDestPanel;
	public Thanks thanksPanel;
	public MapController mapController;

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
		Events.OnMapClicked += OnMapClicked;
		ResetPanels ();
		Next ();
	}
	void ResetPanels()
	{
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
		case 4:
			chooseDestPanel.Init ();
			break;
		case 5:
			thanksPanel.Init ();
			break;
		}
	}
	void OnMapClicked(Vector3 pos)
	{
		switch (id) {
		case 3:			
			placeItPanel.Done ();
			Data.Instance.userDataActive.coordsOrigen = pos;
			mapController.AddUser (Data.Instance.userDataActive);
			break;
		case 4:
			Data.Instance.userDataActive.coordsDestino = pos;
			chooseDestPanel.Done ();
			mapController.Reset ();
			mapController.AddUser (Data.Instance.userDataActive);
			break;
		}
	}
}
