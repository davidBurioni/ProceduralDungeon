using UnityEngine;


public class ControllerCamera : MonoBehaviour
{
    public Transform camera, Owner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            camera.localPosition += new Vector3(0, 0.2f, -0.4f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            camera.localPosition -= new Vector3(0, 0.2f, -0.4f);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("MenuScene");
        }
        camera.LookAt(Owner);
    }
}
