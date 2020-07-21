using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayer : MonoBehaviour
{
    public GameObject Shield;
    float timer;
    int timerForShield;
    bool shieldActive;
    PlayerLife pf;

    // Start is called before the first frame update
    void Start()
    {
        Shield.SetActive(false);
        timerForShield = 10;
        timer = timerForShield;
        pf = transform.GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            shieldActive = true;
            pf.shieldOn = true;
        }
        if (shieldActive == true)
        {
            Shield.SetActive(true);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Shield.SetActive(false);
                timer = timerForShield;
                shieldActive = false;
                pf.shieldOn = false;
            }
        }

    }
}
