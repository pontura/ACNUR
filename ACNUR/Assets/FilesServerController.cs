using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class FilesServerController : MonoBehaviour {

	public List<string> itemsLoaded;
	public DataSettings dataSettings;	


	[System.Serializable]
	public class DataSettings
	{
	//	public string server = "http://192.168.1.89/";
	}

	void Start()
	{
		LoadSettings();
		if(Data.Instance.build == Data.builds.FULL_SCREEN_MAP)
			OnSettingsLoaded();
	}
	
	void LoadSettings()
	{
	//	string Path = Application.streamingAssetsPath + "/settings.json";
	//	string jsonString = File.ReadAllText (Path);
	//	dataSettings = JsonUtility.FromJson<DataSettings> (jsonString);
	}
	void OnSettingsLoaded()
	{	
		Loop ();
	}
	void Loop()
	{
		GetAllFiles ();
		//Invoke ("Loop", 2);
	}
	void GetAllFiles()
	{
		var url = Data.Instance.URL + "load.php";
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		if (www.error == null)
		{
			ParseData ( www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
	void ParseData(string data)
	{
		//Events.Log("Data Server Received");
		string[] imageData = data.Split (";"[0]);
		foreach (string imageName in imageData) {
			if (imageName.Length > 1) {
				string file = (Data.Instance.URL + "photos/" + imageName);
				StartCoroutine(LoadItem(file, imageName));
			}
		}
	}
	public IEnumerator LoadItem(string absoluteImagePath, string imageName)
	{
		itemsLoaded.Add (imageName);

		string finalPath;
		WWW localFile;

		finalPath = absoluteImagePath;
		localFile = new WWW (finalPath);

		yield return localFile;

		//if (!fileWasLoaded (imageName)) {
			Texture2D tex;
			tex = new Texture2D(256, 256, TextureFormat.DXT1, false);

			localFile.LoadImageIntoTexture(tex);
			Events.OnNewFile (tex, imageName);
		//}

		if(!Data.Instance.DEBUG)
		{
			
			var url = Data.Instance.URL + "delete.php?imageName=" + imageName;
			WWW www = new WWW (url);
			Debug.Log("delete: " + url);
		}
	}
	bool fileWasLoaded(string imageName)
	{
		foreach (string oldImageName in itemsLoaded)
			if (oldImageName == imageName)
				return true;
		return false;
	}




}
