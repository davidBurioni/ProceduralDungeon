using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform parentObj;
    Vector3 offset = new Vector3(0, 1, 4);

    void Update()
    {
        transform.position = parentObj.position + offset;
    }
}
