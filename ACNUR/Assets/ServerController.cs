using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerController : MonoBehaviour {


	public void Save()
	{
		StartCoroutine (UploadPNG ());
	}
	IEnumerator UploadPNG()
	{
		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = Data.Instance.photo;

		byte[] bytes = tex.EncodeToPNG();
		//Object.Destroy(tex);

		string file_Name = 
			Data.Instance.userDataActive.username + "=" + 
			(int)(Data.Instance.userDataActive.coordsOrigen.x*1000000) + "=" + 
			(int)(Data.Instance.userDataActive.coordsOrigen.y*1000000) + "=" + 
			(int)(Data.Instance.userDataActive.coordsDestino.x*1000000) + "=" + 
			(int)(Data.Instance.userDataActive.coordsDestino.y*1000000)+ ".png";


		WWWForm form = new WWWForm();
		form.AddField("imageName", file_Name);
		form.AddBinaryData("fileToUpload", bytes);
		WWW w = new WWW(Data.Instance.URL + "upload.php", form);
		yield return w;

		if (w.error != null)
		{
			Debug.Log(w.error);
		}
		else
		{
			Debug.Log("Finished Uploading Screenshot to " + Data.Instance.URL);
		}
	}
}
