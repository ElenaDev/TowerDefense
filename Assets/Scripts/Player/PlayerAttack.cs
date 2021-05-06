using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    Collider colliderAttack;
    private void Awake()
    {
        anim = transform.parent.GetComponent<Animator>();
        colliderAttack = GetComponent<Collider>();
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");       
    }
    //Función que habilitad el collider para hacer daño al enemigo
    public void AttackWithCollider()
    {
        colliderAttack.enabled = true;
        Invoke("DisableCollider", 0.1f);
    }
    void DisableCollider()
    {
        colliderAttack.enabled = false;
    }
}
