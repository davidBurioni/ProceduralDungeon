using UnityEngine;

public class WarpPlant : MonoBehaviour
{
    public GameObject Particel;
    GameObject player;
    Vector3 dist;

    // Start is called before the first frame update
    void Start()
    {
        WarpsManager.warps.Add(this);
        player = ProceduralMap.pla;
        Particel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dist = player.transform.position - transform.position;
        if (dist.magnitude <= 2 && WarpsManager.ICollide == false)
        {
            WarpsManager.ICollide = true;
        }

        if (dist.magnitude <= 5)
            Particel.SetActive(true);
        else
            Particel.SetActive(false);
    }
}
