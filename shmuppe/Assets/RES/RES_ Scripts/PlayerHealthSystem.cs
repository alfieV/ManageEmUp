using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Dead();
        }
    }

    public void TakeDmg(int dmg)
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
            TakeDmg(1);
        }
    }

    void Dead()
    {
        GameManager.Instance.GameOver();
    }
}
