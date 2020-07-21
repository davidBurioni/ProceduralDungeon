using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTranslate: MonoBehaviour {
	public bool performUpdate;
	public Vector3 move;
    float f=0;

    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }
	void Update () {
		if (performUpdate) {
            f +=.01f;
			transform.Translate (move.x * Time.deltaTime, move.y * Time.deltaTime, move.z * Time.deltaTime);
            transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0.4f, 0.4f, 0.4f), f);
		}
	}
}
