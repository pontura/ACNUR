using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZonasManager : MonoBehaviour {

	public GameObject[] all;
	public ConfictData conflictDataPanel;
	public Text title;
	public Text content;
	
	void Start()
	{
		Reset();
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
			id = 9;
		
		all[id].SetActive(true);

		ZonaContent zona= Data.Instance.conflictData.jsonContent.zonas[id];

		conflictDataPanel.SetActive(true);
		Vector3 pos = all[id].localPosition;
		conflictDataPanel.transform.localPosition = pos;
		title.text = zona.title;
		content.text = zona.content; 
	}

}
