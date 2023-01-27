using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashColiider : MonoBehaviour
{
    private PlayerMoviment player;
    void Start()
    {
        player = FindObjectOfType<PlayerMoviment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator morte(){
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("SoloMorte")){
            player.anim.SetTrigger("dead");
            player.estaMovendo = false;
            Destroy(this.gameObject);
            StartCoroutine("morte");
            
   
        }
    }
}
