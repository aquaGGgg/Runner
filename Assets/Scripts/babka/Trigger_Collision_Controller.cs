using UnityEngine;
using System;


public class Trigger_Collision_Controller : MonoBehaviour
{
    public static event Action OnDeath;
    public static event Action OnMagneting; 
    public static event Action OnTakeCoin;
    public GameObject shild;

    private bool _isSheald;


    void Start(){
       OnMagneting?.Invoke();  
    }


    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("barer") && !_isSheald){
            OnDeath?.Invoke();
        }else if(other.gameObject.CompareTag("barer") && _isSheald){
            Destroy(other.gameObject);
            shild.SetActive(false);
            _isSheald = false;
            }


        if (other.gameObject.CompareTag("Shild")){
            Destroy(other.gameObject);
            shild.SetActive(true);
            _isSheald = true;
        }


        if (other.gameObject.CompareTag("Magnet")){
            OnMagneting?.Invoke(); 
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("coin")){
            OnTakeCoin?.Invoke();
            Destroy(other.gameObject);
        }
    
    }

}






