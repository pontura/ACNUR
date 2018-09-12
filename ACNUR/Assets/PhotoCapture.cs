using UnityEngine;
using System.Collections;
using System.Linq;


public class PhotoCapture : MonoBehaviour
{
	PhotoCapture photoCaptureObject = null;
	Texture2D targetTexture = null;

	// Use this for initialization
	void Start()
	{
		Resolution cameraResolution = PhotoCapture..SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
		targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height);

		// Create a PhotoCapture object
		PhotoCapture.CreateAsync(false, delegate(PhotoCapture captureObject) {
			photoCaptureObject = captureObject;
			UnityEngine.XR.WSA.WebCam.CameraParameters cameraParameters = new UnityEngine.XR.WSA.WebCam.CameraParameters();
			cameraParameters.hologramOpacity = 0.0f;
			cameraParameters.cameraResolutionWidth = cameraResolution.width;
			cameraParameters.cameraResolutionHeight = cameraResolution.height;
			cameraParameters.pixelFormat = UnityEngine.XR.WSA.WebCam.CapturePixelFormat.BGRA32;

			// Activate the camera
			photoCaptureObject.StartPhotoModeAsync(cameraParameters, delegate(UnityEngine.XR.WSA.WebCam.PhotoCapture.PhotoCaptureResult result) {
				// Take a picture
				photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
			});
		});
	}

	void OnCapturedPhotoToMemory(UnityEngine.XR.WSA.WebCam.PhotoCapture.PhotoCaptureResult result, UnityEngine.XR.WSA.WebCam.PhotoCaptureFrame photoCaptureFrame)
	{
		// Copy the raw image data into our target texture
		photoCaptureFrame.UploadImageDataToTexture(targetTexture);

		// Create a gameobject that we can apply our texture to
		GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
		Renderer quadRenderer = quad.GetComponent<Renderer>() as Renderer;
		quadRenderer.material = new Material(Shader.Find("Custom/Unlit/UnlitTexture"));

		quad.transform.parent = this.transform;
		quad.transform.localPosition = new Vector3(0.0f, 0.0f, 3.0f);

		quadRenderer.material.SetTexture("_MainTex", targetTexture);

		// Deactivate our camera
		photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
	}

	void OnStoppedPhotoMode(UnityEngine.XR.WSA.WebCam.PhotoCapture.PhotoCaptureResult result)
	{
		// Shutdown our photo capture resource
		photoCaptureObject.Dispose();
		photoCaptureObject = null;
	}
}