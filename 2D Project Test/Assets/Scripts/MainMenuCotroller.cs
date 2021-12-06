using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuCotroller : MonoBehaviour
{
    public GameObject exitpanel;

    private void Start()
    {
        if (Time.timeScale==0)
        {
            Time.timeScale = 1;
        }
    }
    public void ExitGame()
    {
       exitpanel.SetActive(true);

        Time.timeScale = 0;
    }
    public void Answer(string answer)
    {

        if (answer=="yes")
        {
            Application.Quit();
        }
        else
        {
            exitpanel.SetActive(false);

        }


    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
