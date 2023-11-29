using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnManager : MonoBehaviour
{   
    public void btnReplay()
    {
        //DeadMenu.SetActive(false);        
        //Scene currentScene = SceneManager.GetActiveScene();
        PlayerMovement.isDead = false;
        SceneManager.LoadScene("Assignment1");
        Time.timeScale = 1f;
    }
}
