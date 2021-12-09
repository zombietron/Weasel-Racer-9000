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
    public SpawnableItem itemDrop;

    public float size;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        followObject = GameObject.FindGameObjectWithTag("Player").transform;
        SetScale();
    }

    private void FixedUpdate()
    {
        agent.destination = followObject.position;

    }

    public virtual void IDied()
    {
        var go = Instantiate<GameObject>(itemDrop.Collectible);
        go.transform.position = transform.position;
        GameManager.Manager.CurrentScore += pointValue;

    }

    //made this overridable as well
    public virtual void SetScale()
    {
        transform.localScale *= size;
    }

    //made this overridable from child classes to change damage amount
    public virtual void DealDamage()
    {
        Player.Health -= 1;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && GameManager.Manager.running)
        {
            DealDamage();
            Debug.Log("Hit a player! Player health is : " + Player.Health);
        }
    }


}

