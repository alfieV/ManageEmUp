using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] float maxHealth;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDmg(float dmg)
    {
        currentHealth -= dmg;

        if(currentHealth <= 0)
        {
            Dead();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            TakeDmg(1f);
        }
    }

    void Dead()
    {
        /// <summary>
        /// what happen when he dies
        /// </summary>
        Destroy(gameObject);
    }
}
