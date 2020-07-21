using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BuildNavMesh : MonoBehaviour
{
   public NavMeshSurface surface;
    bool Update2 = false;
    void Start()
    {
        surface.RemoveData();
        surface.BuildNavMesh();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.U))
            Update2 = true;
        else
            Update2 = false;

        if(Update2==true)
        {
            surface.RemoveData();
            surface.BuildNavMesh();
        }
    }

}
