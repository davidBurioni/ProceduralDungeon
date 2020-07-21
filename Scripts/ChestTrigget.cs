using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTrigget : MonoBehaviour
{
    ShootManager sm;
    Animator anim;
    SetChestDrop drop;
    public GameObject[] Bullets;
    int showDrop;
    Vector3 dist;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponentInChildren<Animator>();
        showDrop = 0;
        player = ProceduralMap.pla;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            dist = player.transform.position - transform.position;
            if(dist.magnitude <= 1)
            {
                int random = Random.Range(0, Bullets.Length);
                if (showDrop==0)
                {
                    GameObject go = Instantiate(Bullets[random]);
                    go.transform.position = transform.position;
                    //Debug.Log("Chest OnTriggerEnter_Press C_ Random: " + random);
                    anim.SetTrigger("Input");
                    sm = player.transform.GetComponent<ShootManager>();
                    sm.SetBullet(random);
                    showDrop++;
                }
            }
        }
    }
    //void OnTriggerStay(Collider c)
    //{
    //    Debug.Log(gameObject.name + " OnTriggerStay");
    //    if (c.gameObject.transform.tag == "Player")
    //    {
    //        //Debug.Log(gameObject.name + " OnTriggerStay Player ENter");

    //        if (SetChestDrop.DropOn == true)
    //        {
    //            int random = Random.Range(0, Bullets.Length);
    //            if (showDrop == 0)
    //            {
    //                GameObject go = Instantiate(Bullets[random]);
    //                go.transform.position = transform.position;
    //                //Debug.Log("Chest OnTriggerEnter_Press C_ Random: " + random);
    //                anim.SetTrigger("Input");
    //                sm = ParseMaps.pla.transform.GetComponent<ShootManager>();
    //                sm.SetBullet(random);
    //                showDrop++;
    //            }
    //        }
    //    }
    //}
}
