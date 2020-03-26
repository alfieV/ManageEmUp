using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    ScoreSystem sco;
    private int score;
    private int hp;
    PlayerHealthSystem plhp;
    string heart = "♥";
    string life;
    // Start is called before the first frame update
    void Start()
    {
        sco = GameObject.Find("GameManager").GetComponent<ScoreSystem>();
        plhp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        score = sco.Score;
        transform.GetChild(0).GetComponent<Text>().text = "Score" + score.ToString();
        hp = plhp.currentHealth;
        life = string.Empty;
        
        if (hp > 99)
        {
            life = "+99♥";
        }
        else
        {
            for (int i = 0; i < hp; i++)
            {
                life += heart;
            }
        }
        transform.GetChild(1).GetComponent<Text>().text = life;
    }
}
