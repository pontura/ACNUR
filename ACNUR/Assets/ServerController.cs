using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerController : MonoBehaviour {

	string URL = "http://localhost/ACNUR/";

	public void Save()
	{
		StartCoroutine (UploadPNG ());
	}
	IEnumerator UploadPNG()
	{
		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = Data.Instance.photo;

		// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG();
		Object.Destroy(tex);

		string file_Name = Random.Range(0,1000).ToString() + System.DateTime.Now.Hour + "" + System.DateTime.Now.Minute + "" + System.DateTime.Now.Second + "" + System.DateTime.Now.Millisecond + ".png";
		//var fileName = Application.dataPath + "/" + file_Name;

		//File.WriteAllBytes(fileName, bytes);

		// Create a Web Form
		WWWForm form = new WWWForm();
		form.AddField("imageName", file_Name);
		form.AddBinaryData("fileToUpload", bytes);
		WWW w = new WWW(URL + "upload.php", form);
		yield return w;

		if (w.error != null)
		{
			Debug.Log(w.error);
		}
		else
		{
			Debug.Log("Finished Uploading Screenshot to " + URL);
		}
	}
}
