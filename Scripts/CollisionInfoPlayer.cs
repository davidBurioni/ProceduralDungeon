using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInfoPlayer : MonoBehaviour
{
    PickableItem i;
    GameObject go;

    void OnCollisionEnter(Collision c)
    {
        Debug.Log(transform.name + " On collision Enter" + c.transform.name);
        if (c.transform.tag == "Diamond")
        {
            i = c.transform.GetComponentInParent<PickableItem>();
            Debug.Log("PATH: " + i.item.objPath);
            //go = Instantiate(Resources.Load<GameObject>(i.item.objPath), transform.position, transform.rotation);
            EventMng.OnItemPicked.Invoke(i.item, c.gameObject);
            Destroy(c.gameObject);
            //Destroy(go);

            //c.gameObject.SetActive(false);
        }
    }
}
