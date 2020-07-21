using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    float showDrop;
    Vector3 dist;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        showDrop = 0;
        player = ProceduralMap.pla;
    }

    void Update()
    {
        dist = player.transform.position - transform.position;
        if(dist.magnitude <=2)
        {
            if(Input.GetKey(KeyCode.C))
            {
                SetFlyMode.FlyModeON = true;
                showDrop++;
            }
        }
    }
}
