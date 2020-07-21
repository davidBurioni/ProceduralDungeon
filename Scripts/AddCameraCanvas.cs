using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddCameraCanvas : MonoBehaviour
{
    public Canvas canvas;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        canvas.worldCamera = camera;
    }

  
}
