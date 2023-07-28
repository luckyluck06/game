using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TPprog : MonoBehaviour
{
    public string nextLevel = "";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        SceneManager.LoadScene(nextLevel);
    }
}