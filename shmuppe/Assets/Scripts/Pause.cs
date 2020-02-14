using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                transform.GetChild(0).gameObject.SetActive(true);
                paused = true;
            }
            else if (paused)
            {
                Time.timeScale = 1;
                transform.GetChild(0).gameObject.SetActive(false);
                paused = false;
            }
        }
    }
}
