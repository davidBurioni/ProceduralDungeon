using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChestDrop : MonoBehaviour
{
    public static bool DropOn;

    void Start()
    {
        DropOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            DropOn = true;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            DropOn = false;
        }
    }
}
