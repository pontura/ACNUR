using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSlot : MonoBehaviour {
	
	public SpriteRenderer spriteRenderer;
	public UserData userData;
	float timer;
	Vector3 initialScale;

	public void Init(UserData userData)
	{
		initialScale = transform.localScale;
		this.userData = userData;

		spriteRenderer.sprite = Sprite.Create(userData.texture, new Rect(0.0f, 0.0f, userData.texture.width, userData.texture.height), new Vector2(0.5f, 0.5f), 1000.0f);

		if (userData.coordsDestino != Vector2.zero) {
			timer = Vector2.Distance (userData.coordsOrigen, userData.coordsDestino);
			Restart ();
		}
	}
	public void Restart()
	{
		transform.localScale = Vector3.zero;
		transform.position = userData.coordsOrigen;
		iTween.ScaleTo(gameObject, iTween.Hash(
			"scale", initialScale,
			"time", 1.5f,
			"easetype", iTween.EaseType.easeOutElastic,
			"oncomplete", "StartMoveing",
			"oncompletetarget", this.gameObject
			// "axis", "x"
		));
	}
	void StartMoveing()
	{
		iTween.MoveTo(gameObject, iTween.Hash(
			"position", new Vector3(userData.coordsDestino.x, userData.coordsDestino.y, -1),
			"time", timer,
			"easetype", iTween.EaseType.linear,
			"oncomplete", "ScaleToZero",
			"oncompletetarget", this.gameObject
			// "axis", "x"
		));
	}
	void ScaleToZero()
	{
		iTween.ScaleTo(gameObject, iTween.Hash(
			"scale", Vector3.zero,
			"time", 1.5f,
			"easetype", iTween.EaseType.easeInElastic,
			"oncomplete", "Restart",
			"oncompletetarget", this.gameObject
			// "axis", "x"
		));
	}

}
