using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCountLIst : MonoBehaviour
{
   void OnDisable()
    {
        Inventory.DiamondCount++;
    }
   
}
