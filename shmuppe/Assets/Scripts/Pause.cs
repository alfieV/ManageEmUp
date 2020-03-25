using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 1 )
        {
            if (!GameManager.Instance.gamePause)
            {
                Time.timeScale = 0;
                transform.GetChild(0).gameObject.SetActive(true);
                GameManager.Instance.gamePause = true;
            }
            else if (GameManager.Instance.gamePause)
            {
                Time.timeScale = 1;
                transform.GetChild(0).gameObject.SetActive(false);
                GameManager.Instance.gamePause = false;
            }
        }
        else if(!GameManager.Instance.gamePause && transform.GetChild(0).gameObject.activeInHierarchy)
        {
            Time.timeScale = 1;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
