using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    Animator anim;
    GameObject enemy;
    EnemyHealth enemyHealth;

    Vector3 posToGo;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Facu");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (!enemyHealth.death)
        {
            posToGo = enemy.transform.position;
            CanAllyAttack();
        }
        else posToGo = player.transform.position;

        //SetDestination hace que el gameobject se mueva hacia la posición (Vector3) que le digamos
        agent.SetDestination(posToGo);

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
    void CanAllyAttack()
    {
        //si tengo el enemigo a tiro
        if(Vector3.Distance(enemy.transform.position, transform.position) <= agent.stoppingDistance)
        {
            //si estoy en el estado de Idle (en el animator)
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
            {
                //Ataco a tope
                AttackAnimation();
            }               
        }
    }
    void AttackAnimation()
    {
        anim.SetInteger("SwitchAttack", Random.Range(0, 2));
        anim.SetTrigger("Attack");
    }
}
