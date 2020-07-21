using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float Nrg { get { return energy; } }
    float energy;
    int defense;
    public GameObject[] ObjDrops;

    // Start is called before the first frame update
    void Start()
    {
        energy = Random.Range(50, 101);
        defense = Random.Range(0, 16);
    }

    void AddDamage(int damage)
    {
        int realDamage = damage - defense;
        if (energy > realDamage)
        {
            energy -= realDamage;
        }
        else
        {
            RandomDrop();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void RandomDrop()
    {
        int random = Random.Range(0, ObjDrops.Length);
        GameObject go = Instantiate(ObjDrops[random]);
        go.transform.position = transform.position;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Bullet")
        {
            AddDamage(20);
            //Debug.Log("Enemy: " + c.gameObject.name + ", Nrg: " + energy);
        }
        if (c.gameObject.tag == "BulletFire")
        {
            AddDamage(40);
            //Debug.Log("Enemy: " + c.gameObject.name + ", Nrg: " + energy);
        }
        if (c.gameObject.tag == "BulletIce")
        {
            AddDamage(60);
            //Debug.Log("Enemy: " + c.gameObject.name + ", Nrg: " + energy);
        }
        if (c.gameObject.tag == "SpecialBullet")
        {
            AddDamage(100);
            //Debug.Log("Enemy: " + c.gameObject.name + ", Nrg: " + energy);
        }
    }
}
