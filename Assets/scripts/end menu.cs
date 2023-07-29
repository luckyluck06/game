using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     SoundManager.manager.PlayMusic(SoundManager.MENU);
    }
        public void EndGame()

    {
       
        SceneManager.LoadScene("start menu");

    }
    }

    // Update is called once per frame
    
