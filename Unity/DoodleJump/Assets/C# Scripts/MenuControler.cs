using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
  void Start()
  {

  }

  void Update()
  {

  }

  // Начать игру
  public void PlayPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }

  // Выйти из игры
  public void ExitPressed()
    {
        Application.Quit();
        // Проверка того, что выход работает
        Debug.Log("Exit pressed!");
    }
}
