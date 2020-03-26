using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] int startHealth = 100;
    public int currentHealth;
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

    void Dead()
    {
        scosy.Score = points;
        Destroy(gameObject);
    }
}
