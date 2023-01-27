using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public AudioSource musicaMenu;
    public AudioClip musica;
    void Start()
    {
        AudioClip musicaDeFundoMenu = musica;
        musicaMenu.clip = musicaDeFundoMenu;
        musicaMenu.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
