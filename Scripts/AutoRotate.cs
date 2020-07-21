using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {
	public bool performUpdate;
	public float angle;
    public float speed;

	void Update () {
		if (performUpdate) {
			transform.Rotate (0,  speed *angle * Time.deltaTime, 0);
		}
	}
}
