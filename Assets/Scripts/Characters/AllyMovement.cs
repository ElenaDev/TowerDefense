using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Facu");
    }
    void Start()
    {
        
    }

    void Update()
    {
        //SetDestination hace que el gameobject se mueva hacia la posición (Vector3) que le digamos
        agent.SetDestination(player.transform.position);

        Animating();
    }
    void Animating()
    {
        //el módulo del vector velocidad vale cero, es decir, no se esá moviendo
        if(agent.velocity.magnitude <= 0.01)
        {
            //con SetBool establecemos el valor de un parámetro booleando del animator
            anim.SetBool("IsRunning", false);
        }
        else//si no se mete en el if, se mete aquí, y significa que se está moviendo
        {
            anim.SetBool("IsRunning", true);
        }
    }
}
