using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Slider slider;

    public bool death;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;//para que se corresponda el máximo valor del slider con la vida máxima del enemigo
        slider.value = slider.maxValue;       
    }

    public void TakeDamage(int amount)
    {
        anim.SetTrigger("Hit");
        currentHealth -= amount;
        slider.value = currentHealth;//actualizo el valor del slider

        if(currentHealth <=0)
        {
            Death();
        }
    }
    void Death()
    {
        death = true;
        anim.SetTrigger("Death");
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AttackPlayer"))
        {
            //TakeDamage(other.GetComponent<PlayerAttack>().damage);
            TakeDamage(DataManager.dataManager.facu.damage);
        }
        else if (other.CompareTag("AttackHero"))
        {
            //TakeDamage(other.GetComponent<PlayerAttack>().damage);
            TakeDamage(DataManager.dataManager.hero.damage);
        }
    }
}
