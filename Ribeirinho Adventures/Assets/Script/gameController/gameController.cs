using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static gameController gc;
    public Text trashText;
    public int lixos;

    void Awake()
    {
        if(gc ==null){
            gc = this;
        }else if (gc != this){
            Destroy(gameObject);
        }
    }

  
    void Update()
    {
        
    }
}
