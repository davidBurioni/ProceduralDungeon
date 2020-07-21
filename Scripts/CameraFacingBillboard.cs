    using UnityEngine;
using System.Collections;

public enum  facingOrientation{up, down, forward, back, left, right}

public class CameraFacingBillboard : MonoBehaviour
{
	public Camera cam;
	public facingOrientation orientation;
	public float rotateTowardsInc = 100f;
	public bool lockAxis, smooth;

	void Update()
	{
		//Calculate the direction to the camera. dirToCam is a vector
		//going from our position to the camera
		Vector3 dirToCam = cam.transform.position - transform.position;

		Vector3 fromRotation = Vector3.zero;
		if (orientation == facingOrientation.up)
			fromRotation = Vector3.up;
		else if (orientation == facingOrientation.down)
			fromRotation = Vector3.down;
		else if (orientation == facingOrientation.forward)
			fromRotation = Vector3.forward;
		else if (orientation == facingOrientation.back)
			fromRotation = Vector3.back;
		else if (orientation == facingOrientation.left)
			fromRotation = Vector3.left;
		else if (orientation == facingOrientation.right)
			fromRotation = Vector3.right;

        Quaternion finalRotation;
		if (lockAxis) {
            //Use of LookRotation(): we specify what direction we want to look at,
            //and what is our up vector.
            //In this case our forward vector is rotated in order to match (dirToCam).normalized direction
            finalRotation = Quaternion.LookRotation (dirToCam, fromRotation);
		} else {
            //Use of FromToRotation(). Creates a rotation wich rotates from fromDirection to toDirection.
            finalRotation = Quaternion.FromToRotation (fromRotation, dirToCam);
		}
        if(smooth){
            //Use of RotateTowards(): we specify fromDirection and toDirection, and how
			//many degrees we want to increse our rotation
			transform.rotation = Quaternion.RotateTowards (	transform.rotation,
                                                            finalRotation,
															rotateTowardsInc * Time.deltaTime);
		}
        else
        {
            transform.rotation = finalRotation;
        }
	}
}