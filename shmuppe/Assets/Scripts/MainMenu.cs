using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LauchGame()
    {
        SceneManager.LoadScene(0);
        GameObject.Find("GameManager").GetComponent<ScoreSystem>().Reset();
    }
}
