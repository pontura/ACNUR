using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextsManager : MonoBehaviour {

	public GameObject anim;
	public Image profileImage;
	public GameObject cifrasPanel;
	public GameObject percentPanel;
	public GameObject parrafoPanel;
	public GameObject profilePanel;

	public Text cifrasPanel_Title;
	public Text cifrasPanel_Content;

	public Text parrafoPanel_Title;
	public Text parrafoPanel_Content;

	public Text percent_Title;
	public Text percent_Content;

	public Text profile_Title;
	public Text profile_Content;

	public bool isParrafo;
	public int totalParrafos;
	public int parrafoID;

	int timerNext;

	void Start () {
		Invoke("GetNext", 1);
	}
	void ResetAll()
	{
		cifrasPanel.SetActive(false);
		parrafoPanel.SetActive(false);
		percentPanel.SetActive(false);
		profilePanel.SetActive(false);
	}
	void GetNext()
	{
		anim.SetActive(true);
		ResetAll();
		int r = Random.Range(0,100);

		if(isParrafo)
			UseParrafo();
		else if(isProfile)		
			UseProfile();
		else if(r<25)
			UseCifra();
		else if(r<50)
			UsePercent();
		else if(r<75)
			UseParrafo();
		else
			UseProfile();

		Invoke("Loop", 1);
	}
	void Loop()
	{
		if(parrafoID==0 && profileID == 0)
		anim.SetActive(false);
		Invoke("GetNext", 9);
	}
	void UseCifra()
	{
		cifrasPanel.SetActive(true);
		ConfictData.SimpleContent d = Data.Instance.conflictData.GetRandomSimpleContent();
		string title = d.title;
		string content = d.content;
		cifrasPanel_Title.text = title;
		cifrasPanel_Content.text = content;
	}
	void UsePercent()
	{
		percentPanel.SetActive(true);
		ConfictData.SimpleContent d = Data.Instance.conflictData.GetRandomPercentContent();
		string title = d.title;
		string content = d.content;
		percent_Title.text = title;
		percent_Content.text = content;
	}

	ConfictData.ParrafosContent d;
	void UseParrafo()
	{		
		parrafoPanel.SetActive(true);
		if(parrafoID == 0)
		{
			d = Data.Instance.conflictData.GetRandomParrafosContent();
			isParrafo = true;
			totalParrafos = d.content.Length;
		}

		//print("__________" + parrafoID + " total: "+ totalParrafos);

		string title = d.title;
		string content = d.content[parrafoID];

		parrafoPanel_Title.text = title;
		parrafoPanel_Content.text = content;
		
		parrafoID++;

		if(parrafoID >= totalParrafos)
		{
			parrafoID = 0;
			totalParrafos = 0;
			isParrafo = false;
		} 			
	}

	bool isProfile;
	int profileID;
	ConfictData.ProfilesContent profileData;

	void UseProfile()
	{
		profilePanel.SetActive(true);

		if(profileID == 0)
		{
			profileData = Data.Instance.conflictData.GetRandomProfileContent();	
			isProfile = true;
		}			

		profileImage.sprite = Resources.Load<Sprite>( "fotos_perfiles/" + profileData.image) ;

		profile_Title.text = profileData.nombre;

		if(profileID==0)
			profile_Content.text = profileData.desc;
		else
			profile_Content.text = "País de origen: " + profileData.origen + "\nPaís de acogida: " +   profileData.acogida + "\nDeporte: " +  profileData.Deporte;
		

		profileID++;

		if(profileID >= 2)
		{
			profileID = 0;
			isProfile = false;
		} 		
		
	}


}
