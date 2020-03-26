using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int counter = 1;
    public int oneUPValue;
    [SerializeField]
    private PlayerHealthSystem plhp;

    public int Score
    {
        get { return score; }
        set { score = score + value; }
    }
    void Start()
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

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(GameObject.FindGameObjectsWithTag("Player") != null)
        {
            plhp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
        }
    }

    public void Reset()
    {
        score = 0;
        counter = 0;
    }

}
