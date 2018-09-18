using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilesManager : MonoBehaviour {

	MapController mapController;

	void Start () {
		mapController = GetComponent<MapController> ();
		Events.OnNewFile += OnNewFile;
	}

	void OnDestroy () {
		Events.OnNewFile -= OnNewFile;
	}
	void OnNewFile(Texture2D texture, string fileName)
	{
		print ("OnNewFile: " + fileName);
		UserData userdata = new UserData ();
		userdata.texture = texture;
		string[] imageData1 = fileName.Split ("."[0]);
		string[] imageData = imageData1[0].Split ("="[0]);
		userdata.username = imageData [0];
		userdata.coordsOrigen = new Vector2 (float.Parse (imageData [1]) / 1000000, float.Parse (imageData [2]) / 1000000);
		userdata.coordsDestino = new Vector2 (float.Parse (imageData [3]) / 1000000, float.Parse (imageData [4]) / 1000000);
		mapController.AddUser (userdata);
	}
}
