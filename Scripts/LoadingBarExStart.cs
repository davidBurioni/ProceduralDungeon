using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadingBarExStart : MonoBehaviour
{
    public Image loadingBar;    //Filled img

    public float loadingIncVal;
    PlayerLife pf;
    GameObject player;
    float nrg;

    void Start()
    {
        player = ProceduralMap.pla;
        pf = player.transform.GetComponent<PlayerLife>();
        loadingBar.transform.localScale = new Vector3(1, 1, 1);
    }

    void Update()
    {
        nrg = pf.Nrg;
        float normalizedNrg = nrg / 100;
        loadingBar.transform.localScale = new Vector3(normalizedNrg, 1, 1);
    }
}
