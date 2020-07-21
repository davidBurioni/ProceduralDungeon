using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static float MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainAxisHorizontal") * Time.deltaTime;
        r += Input.GetAxis("J_MainAxisHorizontal") * Time.deltaTime;
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 Rotation()
    {
        float r = 0.0f;
        float r2 = 0.0f;

        r += Input.GetAxis("RightJoystickHorizontal") * Time.deltaTime;
        r2 += Input.GetAxis("RightJoystickVertical") * Time.deltaTime;
        //Mathf.Clamp(r, -1.0f, 1.0f);
        return new Vector3(0, r * 50, 0);
    }
    public static float MainVertical()
    {
        float r = 0.0f;
        r -= Input.GetAxis("J_MainAxisVertical")*Time.deltaTime;
        r -= Input.GetAxis("J_MainAxisVertical")*Time.deltaTime;
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 MainJoystick()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }

    public static bool XButton()
    {
        return Input.GetButton("XButton");
    }


    public static bool OButton()
    {
        return Input.GetButton("OButton");

    }

    public static bool RectButton()
    {
        return Input.GetButton("RectButton");

    }

    public static bool TriangleButton()
    {
        return Input.GetButton("YButton");
    }
}
