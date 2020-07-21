using UnityEngine;

public class ObjMoveTRotation : MonoBehaviour
{
    public float speedT = 10;
    public float speedR = 50;
    public string HAxisName = "Horizontal";
    public string VAxisName = "Vertical";

    float HVal;
    float VVal;

    void FixedUpdate()
    {
        HVal = Input.GetAxis(HAxisName) * speedR * Time.deltaTime;
        VVal = Input.GetAxis(VAxisName) * -speedT * Time.deltaTime;
        transform.Rotate(0, HVal, 0);
        transform.Translate(0, 0, VVal);
    }
}
