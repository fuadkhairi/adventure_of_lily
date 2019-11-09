using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
		//this var hold the camera move speed
		public float FollowSpeed = 2f;
		//this var holds the Target followed by Cam
		public Transform Target;

		private void Update()
		{
			//algorhytm for follow
			Vector3 newPosition = Target.position;
			newPosition.z = -10;
			transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
		}
}
