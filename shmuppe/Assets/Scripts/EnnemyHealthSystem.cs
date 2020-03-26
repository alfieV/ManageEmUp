using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealthSystem : MonoBehaviour
{
    [SerializeField] int startHealth = 100;
    private int currentHealth;
    private ScoreSystem scosy;

    [Range(1,100)]public int points;

    private void Start()
    {
        currentHealth = startHealth;
        scosy = GameObject.Find("GameManager").GetComponent<ScoreSystem>();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void TakeDmg(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDmg(1);
        }
    }

    void Dead()
    {
        scosy.Score = points;
        Destroy(gameObject);
    }
}
