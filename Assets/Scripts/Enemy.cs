    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public int pointValue;
    NavMeshAgent agent;
    Transform followObject;

    public float size;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        followObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SetScale();
    }

    private void FixedUpdate()
    {
        agent.destination = followObject.position;

    }

    public void IDied()
    {
        GameManager.Manager.CurrentScore += pointValue;
    }

    public void SetScale()
    {
        transform.localScale *= size;
    }


}
