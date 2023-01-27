using System.Collections;
using System.Collections.Generic;
using  UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public Transform groundCheck;
    public float jumpForce;
   
    
    private float dir; 
    private Rigidbody2D rb;
    public float speed ;

 
     bool isGround ;
    private bool facingRight = true;
    public Animator anim;

    // private HeartBar heartBar;
    // private int health = 100;

    private bool isPaused;
    [Header("Pause")]
    public  GameObject pausePainel;
    public GameObject gameOverPainel;
    public string cena;

    public Rigidbody2D PlayerRb { get => rb; set => rb = value; }


    public gameController gcPlayer;
    
    public bool estaMovendo=true;
    
    void Start()
    {   
        gcPlayer = gameController.gc;
        gcPlayer.lixos = 0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1f;
        
    }

    void Update()
    {   
        
        dir = Input.GetAxisRaw("Horizontal");        
        isGround = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.32f,0.36f),CapsuleDirection2D.Horizontal,0,groundLayer);
        
        if(Input.GetKeyDown(KeyCode.Space) && estaMovendo){
           
            Jump();
        } 

        if(Input.GetAxisRaw("Horizontal")!=0){
            anim.SetBool("taCorrendo",true);
        }else{
            anim.SetBool("taCorrendo",false);
        }


        if(isGround==false){
            anim.SetBool("taPulando",true);
        }else{
            anim.SetBool("taPulando",false);
        }

        

        
        if(estaMovendo==true){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen();
        }}


        if(estaMovendo == false){
            gameOver();
        }
    }
    


    void pauseScreen(){
        if(isPaused){
            isPaused = false;
            pausePainel.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else{

            isPaused = true;
            Time.timeScale = 0f;
            pausePainel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

        void gameOver(){
            gameOverPainel.SetActive(true);
        }


    private void FixedUpdate()
    {
        if(estaMovendo){
            MovPlayer(dir);
       }else{
        StartCoroutine("morte");
       }


        
    }

    private void MovPlayer(float dir){
        rb.velocity = new Vector2(speed * dir, rb.velocity.y);

        if(dir > 0 && !facingRight || dir < 0 && facingRight){
            Flip();
        }

    }

    private void Flip(){
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    private void Jump(){
        if(isGround){
            rb.velocity = Vector2.up * jumpForce;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("lixo")){
            Destroy(collision.gameObject);
           gcPlayer.lixos++;
           gcPlayer.trashText.text = gcPlayer.lixos.ToString();
        }
    }


     IEnumerator morte(){
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }
}
