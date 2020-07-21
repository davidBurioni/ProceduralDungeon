using UnityEngine;
using UnityEngine.UI;


public class SetEnrBarEnemy : MonoBehaviour
{
    public Image loadingBar;    //Filled img
    public CameraFacingBillboard billboard;

    EnemyLife ef;
    GameObject player;
    float nrg;
    Camera camera;

    float normalizedNrg;

    void Start()
    {
        player = ProceduralMap.pla;
        camera = player.transform.GetComponentInChildren<Camera>();
        ef = transform.transform.GetComponent<EnemyLife>();
        loadingBar.transform.localScale = new Vector3(1, 1, 1);
        billboard.cam = camera;
    }

    void Update()
    {
        nrg = ef.Nrg;
        normalizedNrg = nrg / 100;
        loadingBar.transform.localScale = new Vector3(normalizedNrg, 1, 1);
    }
}
