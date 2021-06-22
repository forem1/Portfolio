using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavTest : MonoBehaviour
{
    public Transform target;
    public UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
