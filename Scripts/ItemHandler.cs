using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    GameObject go;

    void Awake()
    {
        EventMng.OnItemRemoved.AddListener(OnItemRemovedCallback);
    }
    void OnItemRemovedCallback(Item i)
    {
        Vector3 randpos = transform.position + this.transform.forward * (UnityEngine.Random.Range(3, 6));
        go = Instantiate(Resources.Load<GameObject>(i.objPath), randpos, transform.rotation);
    }
}
