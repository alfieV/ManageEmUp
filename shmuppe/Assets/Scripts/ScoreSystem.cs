using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int score = 0;

    [Range(1, 100)] public int bulletDamage;

    public int BulletDamage
    {
        get { return bulletDamage; }
    }

    public int Score
    {
        get { return score; }
        set { score = score + value; }
    }

    public void Reset()
    {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
