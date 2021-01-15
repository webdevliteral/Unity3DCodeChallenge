using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        //check distance from target to enemy
        float distance = Vector3.Distance(target.position, transform.position);
        //if within distance, do something
        if(distance <= lookRadius)
        {
            //chase player
            agent.SetDestination(target.position);

            //face player and attack
            if(distance <= agent.stoppingDistance)
            {
                //face player
                FaceTarget();
                //attack target after facing
                CharacterStats targetStats = target.GetComponent<CharacterStats>(); //get the stats of your target
                if(targetStats != null)
                {
                    combat.Attack(targetStats);
                }
                
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
