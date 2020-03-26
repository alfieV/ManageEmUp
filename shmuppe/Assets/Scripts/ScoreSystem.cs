using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

    private int counter = 1;
    public int oneUPValue;
    private PlayerHealthSystem plhp;

    public int Score
    {
        get { return score; }
        set { score = score + value; }
    }
    void start()
    {
        plhp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
    }

    private void Update()
    {
        if (score >counter * oneUPValue)
        {
            plhp.currentHealth++;
            counter++;
        }
    }

    public void Reset()
    {
        score = 0;
        counter = 0;
    }

}
