using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
NavMeshAgent agent;
Transform target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        target = newTarget.interactPosition;
    }

    public void StopFollowTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        //find target direction
        Vector3 direction = (target.position - transform.position).normalized;
        //discover best rotation
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        //smoothly interpolate towards destination
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
