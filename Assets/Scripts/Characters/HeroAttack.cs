using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    Animator anim;
    Collider colliderHero;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        colliderHero = GetComponent<Collider>();
    }
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    //Función la vamos a llamar desde la clase común Hero
    public void Attack()
    {
        colliderHero.enabled = true;
        Invoke("DisableCollider", 0.1f);
    }
    void DisableCollider()
    {
        colliderHero.enabled = false;
    }
}
