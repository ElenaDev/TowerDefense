using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int turnSpeed;
    public bool attackingEnemy;
    public UIManager uiManager;

    [HideInInspector]
    public Vector3 posToGo;

    PlayerAttack playerAttack;
    Animator anim;
    Quaternion rotation;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
    }

    void Start()
    {
        posToGo = transform.position;
        rotation = transform.rotation;
    }

    void Update()
    {
        //si estoy en la posición de destino, no me estoy moviendo, por lo tanto quiero reproducir Idle
        if(transform.position == posToGo)
        {
            anim.SetBool("IsRunning", false);
            if(attackingEnemy == true)
            {
                playerAttack.Attack();
                attackingEnemy = false;
            }
        }
        else//si no estoy en la posición de destino, significa que me estoy moviendo y que voy a reproducir Run
        {
            anim.SetBool("IsRunning", true);
        }
        transform.position = Vector3.MoveTowards(transform.position, posToGo, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
    //Esta función calcula la rotación PERO no le dice al player que rote
    public void Turning(Vector3 target)
    {
        //Vector dirección: vector que hay entre la posición a la que quiero mirar y mi posición
        Vector3 direction = target - transform.position;
        //creo una rotación, pásandole el vector3 que me da la dirección. Lo que hace es alinear el forward del personaje
        //(es decir, hacia donde está mirando) con el vector que yo le paso (direction)
        rotation = Quaternion.LookRotation(direction);
        //con Lerp hacemos rotación gradual de un valor a otro    
    }

    //Esta función se ejecuta cuando el collider del player choca con otro collider trigger de la escena
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hero") || other.CompareTag("Lich"))
        {
            uiManager.SelectCharacter(other.tag);
            Destroy(other.gameObject);
        }

    }
    //Función que vamos a llamar desde evento en la animación
    public void Attack()
    {
        playerAttack.AttackWithCollider();
    }
}
