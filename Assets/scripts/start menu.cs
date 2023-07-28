using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour
{
    public GameObject creditPanel;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    public void Hide()
    {
       creditPanel.SetActive(false); 
    }  
    
    public void Showcredit()
    {
       creditPanel.SetActive(true); 
    }
    public void StartGame()
    {
        SoundManager.manager.PlayMusic(SoundManager.Game);
        SceneManager.LoadScene("LucaScene");
    }



    public void Quit()
    {
       Application.Quit(); 

    }
}
