using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathManager : MonoBehaviour
{
    public GameObject DeadMenu;
    // Start is called before the first frame update
    void Start()
    {
        DeadMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.isDead == true)
        {           
            DeadMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    
}
