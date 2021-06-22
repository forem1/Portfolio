using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {

    }

    void Update()
    {
      if(Input.GetKey(KeyCode.Escape))
      {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

      }
      else if (Input.GetKey(KeyCode.Escape))
      {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
      }
    }

    public void PlayPressed()
      {
          Time.timeScale = 1;
          pauseMenu.SetActive(false);
      }

    public void MenuPressed()
      {
          Time.timeScale = 1;
          SceneManager.LoadScene("MenuScene");
      }
}
