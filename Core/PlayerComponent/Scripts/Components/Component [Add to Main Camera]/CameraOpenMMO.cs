
using UnityEngine;
using OpenMMO;

namespace OpenMMO {

	// ===================================================================================
	// CameraOpenMMO
	// ===================================================================================
	[DisallowMultipleComponent]
	public class CameraOpenMMO : FollowCamera
	{

		[Header("Camera Key")]
		public KeyCode hotKey = KeyCode.LeftControl;

		[Header("Controls")]
		public bool updateRotation = true;
		public bool updateRotationX = false;
		public bool updateRotationY = false;
		public bool updateZoom = true;

		[Header("X Rotation")]
		public bool limitXRotation;
		[Range(-360, 360)]
		public float minXRotation = 0;
		[Range(-360, 360)]
		public float maxXRotation = 0;
		public bool smoothRotateX;
		public float rotateXSmoothing = 10.0f;

		[Header("Y Rotation")]
		public bool limitYRotation;
		[Range(-360, 360)]
		public float minYRotation = 0;
		[Range(-360, 360)]
		public float maxYRotation = 0;
		public bool smoothRotateY;
		public float rotateYSmoothing = 10.0f;

		[Header("General Rotation Settings")]
		public float startXRotation;
		public float startYRotation;
		public float rotationSpeed = 5;

		[Header("Zoom")]
		public bool limitZoomDistance;
		public float minZoomDistance;
		public float maxZoomDistance;
		public bool smoothZoom;
		public float zoomSmoothing = 10.0f;

		[Header("General Zoom Settings")]
		public float startZoomDistance;
		public float zoomSpeed = 5;

		private float xVelocity;
		private float yVelocity;
		private float zoomVelocity;
		
		// -------------------------------------------------------------------------------
		// Start
		// -------------------------------------------------------------------------------
		protected virtual void Start()
		{
			xRotation = startXRotation;
			yRotation = startYRotation;
			zoomDistance = startZoomDistance;
		}
		
		// -------------------------------------------------------------------------------
		// Update
		// -------------------------------------------------------------------------------
		protected virtual void Update()
		{
			
			float deltaTime = Time.deltaTime;
		
			if (Input.GetKey(hotKey))
				useTargetYRotation = false;
			else
				useTargetYRotation = true;
		
			// X rotation
			if (updateRotation || updateRotationX)
				xVelocity += InputManager.GetAxis("Mouse Y", false) * rotationSpeed;
		
			if (Input.GetKey(hotKey))
				xRotation -= xVelocity;
		
			if (limitXRotation)
				xRotation = ClampAngleBetweenMinAndMax(xRotation, minXRotation, maxXRotation);
			else
				xRotation = ClampAngleBetweenMinAndMax(xRotation, -360, 360);

			// Y rotation
			if (updateRotation || updateRotationY)
				yVelocity += InputManager.GetAxis("Mouse X", false) * rotationSpeed;
		
			if (Input.GetKey(hotKey) && !Tools.AnyInputFocused)
				yRotation += yVelocity;
		
			if (limitYRotation)
				yRotation = ClampAngleBetweenMinAndMax(yRotation, minYRotation, maxYRotation);
			else
				yRotation = ClampAngleBetweenMinAndMax(yRotation, -360, 360);

			// Zoom
			if (updateZoom)
				zoomVelocity += InputManager.GetAxis("Mouse ScrollWheel", false) * zoomSpeed;
		
			if (Input.GetKey(hotKey))
				zoomDistance += zoomVelocity;
		
			if (limitZoomDistance)
				zoomDistance = Mathf.Clamp(zoomDistance, minZoomDistance, maxZoomDistance);

			// X rotation smooth
			if (smoothRotateX)
				xVelocity = Mathf.Lerp(xVelocity, 0, deltaTime * rotateXSmoothing);
			else
				xVelocity = 0f;

			// Y rotation smooth
			if (smoothRotateY)
				yVelocity = Mathf.Lerp(yVelocity, 0, deltaTime * rotateYSmoothing);
			else
				yVelocity = 0f;

			// Zoom smooth
			if (smoothZoom)
				zoomVelocity = Mathf.Lerp(zoomVelocity, 0, deltaTime * zoomSmoothing);
			else
				zoomVelocity = 0f;
		}
		
		// -------------------------------------------------------------------------------
		// ClampAngleBetweenMinAndMax
		// -------------------------------------------------------------------------------
		private float ClampAngleBetweenMinAndMax(float angle, float min, float max)
		{
			if (angle < -360)
				angle += 360;
			if (angle > 360)
				angle -= 360;
			return Mathf.Clamp(angle, min, max);
		}
		
		// -------------------------------------------------------------------------------
		
	}
	
	// ===================================================================================

}