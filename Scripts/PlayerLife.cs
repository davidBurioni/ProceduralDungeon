using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    public float Nrg { get { return energy; } }
    public bool shieldOn;

    int defense;
    float energy;
    const int MaxHp = 100;

    // Start is called before the first frame update
    void Start()
    {
        energy = 100;
        defense = 10;
    }

    // Update is called once per frame
    public void AddDamage(int damage)
    {
        if (energy > MaxHp)
            energy = MaxHp;

        if (shieldOn == false)
        {
            int realDamage = damage - defense;
            if (realDamage < energy)
            {
                energy -= realDamage;
            }
            else
            {
                SceneManager.LoadScene("MenuScene");
            }
        }
    }
}
