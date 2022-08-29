using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AILocomotion : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    private Animator chAnimator;

    private NavMeshAgent agent;

    private AudioSource audio_;

    private float separateDistance = 20f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        chAnimator = GetComponent<Animator>();
        audio_ = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = playerTransform.position;
        //Debug.Log(agent.destination);
        chAnimator.SetBool("Attack", true);
        audio_.enabled = true;

        float sqDistance = (playerTransform.position - transform.position).sqrMagnitude;
        //Debug.Log(sqDistance);
        if (sqDistance < separateDistance)
        {
            chAnimator.SetBool("Attack", false);
            audio_.enabled = false;
        }
        
    }
}
