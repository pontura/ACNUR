using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZonasManager : MonoBehaviour {

	public Camera cam;
	public GameObject[] all;
	public GameObject conflictDataPanel;
	public Text title;
	public Text content;
	
	void Start()
	{
		ResetAll();
	}
	void Reset()
	{
		foreach (GameObject go  in all)
			go.SetActive(false);
	}
	public void SetArea()
	{
		Reset();
		int id = Random.Range(0,all.Length);
		if(Data.Instance.userDataActive.coordsDestino.x<0)
			id = 10;
		
		all[id].SetActive(true);

		conflictDataPanel.SetActive(true);

		Vector3 pos = all[id].transform.localPosition;
		Vector3 screenPos = cam.WorldToScreenPoint(pos);
		 screenPos.z = -6;
		conflictDataPanel.transform.position = screenPos;

		ConfictData.ZonaContent zona = Data.Instance.conflictData.jsonContent.zonas[id];		
		title.text = zona.title;
		content.text = zona.content;	 	

	}
	public void ResetAll()
	{
		conflictDataPanel.SetActive(false);
		Reset();
	}

}
