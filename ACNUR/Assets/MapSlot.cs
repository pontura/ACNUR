using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSlot : MonoBehaviour {
	
	public SpriteRenderer spriteRenderer;
	public UserData userData;
	float timer;

	public void Init(UserData userData)
	{
		this.userData = userData;

		spriteRenderer.sprite = Sprite.Create(userData.texture, new Rect(0.0f, 0.0f, userData.texture.width, userData.texture.height), new Vector2(0.5f, 0.5f), 1000.0f);

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
