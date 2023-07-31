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

    public void loadthegame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
