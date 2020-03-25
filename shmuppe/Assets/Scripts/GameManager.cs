using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject gameOverElement = null;
    public bool gamePause;
    public bool inputEnable;
    public bool hideGameOver;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(ParallelUpdate());
    }


    public void GameOver()
    {
        gameOverElement.SetActive(true);
        inputEnable = false;
    }

    public void HideGameOver()
    {
        gameOverElement.SetActive(false);
        inputEnable = true;
    }

    public void ResetScene()
    {
        hideGameOver = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }

    public void GoToMenu()
    {
        hideGameOver = true;
        gamePause = false;
        SceneManager.LoadScene(1);
        
    }

    IEnumerator ParallelUpdate()
    {
        if (gamePause)
        {
            inputEnable = false;
        }
        else if(!gamePause && !inputEnable)
        {
            inputEnable = true;
        }

        if(hideGameOver && gameOverElement.activeInHierarchy)
        {
            gameOverElement.SetActive(false);
            hideGameOver = false;
        }
        else if(hideGameOver && !gameOverElement.activeInHierarchy)
        {
            hideGameOver = false;
        }

        yield return new WaitForSeconds(0.0001f);

        StartCoroutine(ParallelUpdate());
    }
}
