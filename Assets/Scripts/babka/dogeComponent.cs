using UnityEngine;

public class DogeComponent : MonoBehaviour
{   
    private float _jumpForce = 1f;

    private Rigidbody _rb;
    private Animator _anime;
    private BoxCollider _boxCollider;  // Коллайдер персонажа
    private bool _isGrounded;
    private int _poss;

    [SerializeField]
    private bool _isDead;

    /*----------------------------------------------------------------------------*/

    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _rb = GetComponent<Rigidbody>();
        _anime = GetComponent<Animator>();

        Trigger_Collision_Controller.OnDeath += Dead;
        DeadMenu.OnStart +=OnStart;
    }

    /*----------------------------------------------------------------------------*/

    void Update()
    { 


        if(_isGrounded && _anime.GetBool("isJumping") == true){
            _anime.SetBool("isJumping", false);
        }
        
        if(Input.GetKeyDown(KeyCode.D) && !Physics.Raycast(transform.position, Vector3.right, 1f) && _isDead == false){
            //_anime.SetBool("Left_Dodge", true);
            Invoke("DodgeToFalse", 0.1f);
            _poss++;
            transform.position = Vector3.Lerp(transform.position, new Vector3(_poss,transform.position.y, transform.position.z), 1);

        }

        if(Input.GetKeyDown(KeyCode.A) && !Physics.Raycast(transform.position, Vector3.left, 1f) && _isDead == false){
            //_anime.SetBool("Left_Dodge", true);
            Invoke("DodgeToFalse", 0.1f);
            _poss--;
            transform.position = Vector3.Lerp(transform.position, new Vector3(_poss,transform.position.y, transform.position.z), 1);
        }

        if((Input.GetButton("Jump") || Input.GetKeyDown(KeyCode.W)) && _isGrounded && _isDead == false){ //@jump
            _anime.SetBool("isJumping", true);
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, CalculateJumpVelocity(), _rb.linearVelocity.z);
           }


        if(Input.GetKeyDown(KeyCode.S) && _isGrounded){ // @slide
        _boxCollider.size = _boxCollider.size * 0.5f;
        _boxCollider.center = _boxCollider.center * 0.5f;
        _anime.SetBool("isSliding", true);
        Invoke("NonSliding", 0.5f);
        }
    }

    /*----------------------------------------------------------------------------*/

    void NonSliding(){
        _boxCollider.size = _boxCollider.size * 2f;
        _boxCollider.center = _boxCollider.center * 2f;
        _anime.SetBool("isSliding", false);
    }

    /*----------------------------------------------------------------------------*/
    void DodgeToFalse(){
        _anime.SetBool("Left_Dodge", false);
    }

    /*----------------------------------------------------------------------------*/

    void OnCollisionEnter(Collision collision){
       if(collision.gameObject.CompareTag("ground"))
            _isGrounded = true;
    }

    /*----------------------------------------------------------------------------*/

    void OnCollisionExit(Collision collision){
        if(collision.gameObject.CompareTag("ground"))
            _isGrounded = false;
    }

    /*----------------------------------------------------------------------------*/

    float CalculateJumpVelocity()
    {
        return Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * _jumpForce);
    }

    /*----------------------------------------------------------------------------*/

    void Dead(){ 
        _anime.SetBool("isDead", true);
        _isDead = true;
    }

    /*----------------------------------------------------------------------------*/

    void OnStart(){
        _poss = 0;
        _anime.SetBool("isDead", false);
        _isDead = false;
        transform.position = new Vector3(0,-0.4f,-3.58f);
    }

    /*----------------------------------------------------------------------------*/

    //функция - спавн приследователя

    
    

}