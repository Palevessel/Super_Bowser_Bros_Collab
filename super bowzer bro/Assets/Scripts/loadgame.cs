using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadgame : MonoBehaviour
{
   public void quitgame()
   {
        Application.Quit();
        Debug.Log("QUIT");
   }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void Map1()
    {
        SceneManager.LoadScene("Map1");
    }
    public void Map2()
    {
        SceneManager.LoadScene("Map2");
    }
}
