using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    Transform UIPanel;

    bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        UIPanel.gameObject.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        UIPanel.gameObject.SetActive(true);
    }
    public void Unpause()
    {
        isPaused = false;
        UIPanel.gameObject.SetActive(false);
    }

    public void Restart()
    {
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
