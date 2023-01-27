using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    
    [SerializeField] GameObject[] trashPrefab;
    [SerializeField] float secondSpawn ;
    [SerializeField] float minTras = -45.62f;
    [SerializeField] float maxTras = -9.38f;
    public gameController gcPlayer;
    private PlayerMoviment player;
    void Start()
    {
          player = FindObjectOfType<PlayerMoviment>();
          gcPlayer = gameController.gc;
         StartCoroutine(TrashSpawn());
        
       
    }


    private void Update() {
        if(gcPlayer.lixos <5){
            secondSpawn = 3.5f;
            player.speed =15f;
            player.jumpForce = 9f;
        }else if(gcPlayer.lixos >=5){
            secondSpawn = 3.3f;
        }else if(gcPlayer.lixos >10 && gcPlayer.lixos <20){
            secondSpawn = 3.0f;
            player.speed += player.speed*0.10f;
            player.jumpForce += player.jumpForce*0.01f;
        }else if(gcPlayer.lixos >=20){
            secondSpawn = 2.5f;
            player.speed += player.speed*0.10f;
            player.jumpForce += player.jumpForce*0.01f;
        }
    }

    IEnumerator TrashSpawn(){
        
        while(true){
            
            var wanted = Random.Range(minTras,maxTras);
            var position = new Vector3(wanted,transform.position.y);
            GameObject gameObject = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)],
            position,Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject,10f);
        }
    }

    
    
    
    
}
