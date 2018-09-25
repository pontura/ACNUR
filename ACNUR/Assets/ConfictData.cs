using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConfictData : MonoBehaviour {

	public bool reload;
	[System.Serializable]
	public class ZonaContent
	{
		public int id;
		public string title;
		public string content;
	}
	[System.Serializable]
	public class SimpleContent
	{
		public string title;
		public string content;
	}
	[System.Serializable]
	public class ParrafosContent
	{
		public string title;
		public string[] content;
	}
	[System.Serializable]
	public class ProfilesContent
	{
		public string image;
		public string nombre;
		public string desc;
		public string origen;
		public string acogida;
		public string Deporte;
	}
	[System.Serializable]
	public class JsonContent
	{
		public List<SimpleContent> cifras;
		public List<SimpleContent> porcentajes;
		public List<ParrafosContent> parrafos;
		public List<ProfilesContent> profiles;
		public List<ZonaContent> zonas;
		
	}
	public JsonContent jsonContent;

	void Start()
	{
		
		if(reload)
		{
			LoadSettings();
		}
		//if(Data.Instance.build == Data.builds.FULL_SCREEN_MAP)
		//	OnSettingsLoaded();
	}
	
	void LoadSettings()
	{
		string Path = Application.streamingAssetsPath + "/settings.json";
		string jsonString = File.ReadAllText (Path);
		jsonContent = JsonUtility.FromJson<JsonContent> (jsonString);
	}
	public SimpleContent GetRandomSimpleContent()
	{
		return jsonContent.cifras[Random.Range(0,jsonContent.cifras.Count)];
	}
	public ParrafosContent GetRandomParrafosContent()
	{
		return jsonContent.parrafos[Random.Range(0,jsonContent.parrafos.Count)];
	}
	public SimpleContent GetRandomPercentContent()
	{
		return jsonContent.porcentajes[Random.Range(0,jsonContent.porcentajes.Count)];
	}
	public ProfilesContent GetRandomProfileContent()
	{
		return jsonContent.profiles[Random.Range(0,jsonContent.profiles.Count)];
	}
}
