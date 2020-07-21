using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomSpeed : MonoBehaviour
{
    GameObject target;
    Animator anim;
    NavMeshAgent agent;
    Vector3 startPos;

    //Attack
    PlayerLife pf;
    int nextAttack;
    float timerForAttack;

    //Update
    Vector3 dist;
    Vector3 distToOwner;

    // Start is called before the first frame update
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        int random = Random.Range(2, 4);
        agent.speed = random;
        anim = transform.GetComponentInChildren<Animator>();
        startPos = transform.position;
        target = ProceduralMap.pla;
        pf = target.transform.GetComponent<PlayerLife>();
        nextAttack = 1;
        timerForAttack = nextAttack;
    }

    void Update()
    {
        if (target == null)
            target = ProceduralMap.pla;

        dist = target.transform.position - transform.position;
        if (dist.magnitude < 10)
        {
            anim.SetBool("VerifyPos", false);
            anim.SetBool("View", true);
            agent.SetDestination(target.transform.position);
            if (dist.magnitude < 2f)
            {
                agent.SetDestination(transform.position);
                timerForAttack -= Time.deltaTime;
                if (timerForAttack <= 0)
                {
                    anim.SetTrigger("Attack");
                    int randomDamage = Random.Range(15, 30);
                    pf.AddDamage(randomDamage);
                    timerForAttack = nextAttack;
                }
            }
        }
        else
        {
            anim.SetBool("View", false);
            agent.SetDestination(startPos);
            distToOwner = startPos - transform.position;
            if (distToOwner.magnitude <= 1)
            {
                anim.SetBool("VerifyPos", true);
            }
        }
    }
}
