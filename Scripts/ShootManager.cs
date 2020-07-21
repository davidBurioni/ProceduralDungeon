using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public GameObject[] Bullets;
    public GameObject Projector, Particel, Plane, ShotParticel, SpecialBullet;
    public Transform SpawnPoint;

    Animator anim;
    bool isFire;
    float speed = 5;
    bool shoot, specialShoot;
    float timer;
    GameObject bullet;
    bool OnShotSpecial;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        anim = transform.GetComponent<Animator>();
        bullet = Bullets[0];
        Plane.SetActive(false);
        Particel.SetActive(false);
        Projector.SetActive(false);
        ShotParticel.SetActive(false);

        OnShotSpecial = false;
    }
    public void SetBullet(int index)
    {
        bullet = Bullets[index];
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isFire == false)
            {
                anim.SetTrigger("Attack");
                isFire = true;
                shoot = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFire = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (Inventory.DiamondCount >= 2)
            {
                anim.SetTrigger("SpecialAttack");
                isFire = true;
                specialShoot = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFire = false;
        }
    }

    void Update()
    {
        if (shoot == true)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                GameObject go = Instantiate(bullet);
                go.transform.position = SpawnPoint.position;
                Rigidbody rb = go.transform.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
                shoot = false;
                timer = 0;
            }
        }

        if (specialShoot == true)
        {
            Projector.SetActive(true);
            Particel.SetActive(true);
            Plane.SetActive(true);

            timer += Time.deltaTime;
            if (timer > 2.9f)
            {              
                //Effect
                specialShoot = false;
                timer = 0;
                Projector.SetActive(false);
                Particel.SetActive(false);
                Plane.SetActive(false);
                ShotParticel.SetActive(false);
                OnShotSpecial = false;
            }
            else if (timer > 2.4f)
            {
                if (OnShotSpecial == false)
                {
                    OnShotSpecial = true;
                    ShotParticel.SetActive(true);
                    //SHoot
                    GameObject go = Instantiate(SpecialBullet);
                    go.transform.position = SpawnPoint.position;
                    Rigidbody rb = go.transform.GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
                }
                    ShotParticel.transform.rotation = SpawnPoint.rotation;
            }
        }
    }


}
