using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapSlot : MonoBehaviour {
	
	public SpriteRenderer spriteRenderer;
	UserData userData;
	float timer;

	public void Init(UserData userData)
	{
		this.userData = userData;
		//spriteRenderer.sprite = userData.texture;
		if (userData.coordsDestino != Vector2.zero) {
			timer = Vector2.Distance (userData.coordsOrigen, userData.coordsDestino);
			MoveTo ();
		}
	}
	void MoveTo()
	{
		iTween.MoveTo(gameObject, iTween.Hash(
			"position", new Vector3(userData.coordsDestino.x, userData.coordsDestino.y, -1),
			"time", timer,
			"easetype", iTween.EaseType.linear,
			"oncomplete", "DoneMove",
			"oncompletetarget", this.gameObject
			// "axis", "x"
		));
	}
	void DoneMove()
	{
		MoveTo ();
	}
}
