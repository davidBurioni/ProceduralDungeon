using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFlyMode : MonoBehaviour
{
    public static bool FlyModeON;
    int timerPowerUp = 40;
    float timer;
    CharacterController controller;
    Vector3 velocity;
    Vector3 startVelocity;
    public GameObject Particels;

    // Start is called before the first frame update
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
        FlyModeON = false;
        timer = 0;
        velocity = new Vector3(0, 0.2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (FlyModeON == true)
        {
            //Debug.Log("FLy Mode ON");
            timer += Time.deltaTime;
            if (timer <= timerPowerUp)
            {
                Particels.SetActive(true);
                //Debug.Log("FLy Mode ON_RUN");
                SetUpVelocity();
                SetBottomVelocity();
            }
            else
            {
                FlyModeON = false;
                timer = 0;
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
        else
            Particels.SetActive(false);
    }

    public void SetUpVelocity()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            controller.Move(velocity);
        }
    }

    public void SetBottomVelocity()
    {
        if (Input.GetKey(KeyCode.X))
        {
            controller.Move(-velocity);
        }
    }
}
