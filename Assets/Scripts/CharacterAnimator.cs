using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    public AnimationClip replaceableAttackAnim;
    public AnimationClip[] defaultAttackAnimSet;
    protected AnimationClip[] currentAttackAnimSet;

    const float smoothTime = .1f;
    Animator animator;
    NavMeshAgent agent;
    protected CharacterCombat combat;
    public AnimatorOverrideController overrideController;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();
        if(overrideController == null)
        {
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        }
        animator.runtimeAnimatorController = overrideController;
        
        currentAttackAnimSet = defaultAttackAnimSet;
        combat.OnAttack += OnAttack;
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, smoothTime, Time.deltaTime);
        animator.SetBool("inCombat", combat.inCombat);
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("attack");
        int attackIndex = Random.Range(0, currentAttackAnimSet.Length);
        overrideController[replaceableAttackAnim.name] = currentAttackAnimSet[attackIndex];
    }
}
