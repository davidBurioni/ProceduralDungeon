using System.Collections.Generic;
using UnityEngine;

public class WarpsManager : MonoBehaviour
{
    public static List<WarpPlant> warps;
    public static bool ICollide;

    float timerForReloadWarp;
    GameObject player;

    void Awake()
    {
        warps = new List<WarpPlant>();
        ICollide = false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        timerForReloadWarp = 0;
        player = ProceduralMap.pla;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerForReloadWarp > 0)
            timerForReloadWarp -= Time.deltaTime;

        if (ICollide)
        {
            ICollide = false;

            if (timerForReloadWarp <= 0)
            {
                player.transform.GetComponent<CharacterController>().enabled = false;
                float lerp = 0;
                WarpPlant a = GetRandomWarp();
                while (lerp <= 1)
                {
                    lerp += 1 / Time.deltaTime * 5;
                    player.transform.position = Vector3.Lerp(player.transform.position, a.transform.position, lerp);
                }
                player.transform.GetComponent<CharacterController>().enabled = true;
                timerForReloadWarp = 10;
            }
        }
        //Debug.Log("warps is " + warps.Count + " . collide : " + ICollide);
    }

    WarpPlant GetRandomWarp()
    {
        int randIndex = Random.Range(0, warps.Count);

        return warps[randIndex];
    }
}
