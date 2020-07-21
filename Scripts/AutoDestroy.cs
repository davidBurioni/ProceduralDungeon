using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float destroyAfter = 3.0f;

    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }
}
