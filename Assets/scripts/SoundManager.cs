using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager manager;
    public AudioSource musicSource;
    public AudioSource SfxSource;
    public AudioClip MenuClip;
    public AudioClip GameClip;
    public static int MENU = 0;
    public static int Game = 1;
    private int currentMusic = -2;

    public void Awake()

{
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(manager);
        }
        else Destroy(this.gameObject);
}

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic(MENU);   
    }

    // Update is called once per frame
    public void PlayMusic(int type)
    {
        if (type == currentMusic)
            return;
        musicSource.Stop();
        currentMusic = type;
        if (type == MENU)
            musicSource.clip = MenuClip;
        else
            musicSource.clip = GameClip;
        musicSource.Play();

    }
}
