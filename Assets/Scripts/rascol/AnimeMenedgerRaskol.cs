using UnityEngine;

public class AnimeMenedgerRaskol : MonoBehaviour
{
    private Animator _anime;


    void Start()
    {
        Trigger_Collision_Controller.OnDeath +=Fatality;
        DeadMenu.OnStart += OnStart;
        MainMenu.OnPlay += OnStart; // 
        _anime = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
        _anime.SetBool("isSliding", true);
        Invoke("NonSliding", 0.5f);
        }   
    }

    /*----------------------------------------------------------------------------*/

     void OnCollisionEnter(Collision collision){
       if(collision.gameObject.CompareTag("ground"))
            _anime.SetBool("IsJump", false);
    }

    /*----------------------------------------------------------------------------*/

    void OnCollisionExit(Collision collision){
        if(collision.gameObject.CompareTag("ground"))
            _anime.SetBool("IsJump", true);
    }  

    void Fatality(){
        transform.position += Vector3.forward*3;
        _anime.SetBool("IsKill",true);
    }

    void OnStart(){
        _anime.SetBool("IsKill",false);
    }

     void NonSliding(){
        _anime.SetBool("isSliding", false);
    }
}
