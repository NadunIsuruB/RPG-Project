using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float AnimSmoothTime = .1f;

    public NavMeshAgent agent;
    public Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("SpeedPercent", speedPercent, AnimSmoothTime, Time.deltaTime);
    }
}
