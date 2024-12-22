using UnityEngine;
using System;

public class GraundAnimation : MonoBehaviour
{
    [SerializeField]
    private float _scrollY = 0.5f;
    [SerializeField]
    private float _scrollX = 0.5f;

    private static bool isStarting = false;

    void Start(){
        DeadMenu.OnStart += OnStart;
        DeadMenu.GoToMenu += OnEnd;
        Trigger_Collision_Controller.OnDeath +=OnEnd;
    }


    void FixedUpdate()
    {
        if(isStarting){
        float OrffsexY = Time.time * _scrollY;
        float OrffsexX = Time.time * _scrollX;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OrffsexX, OrffsexY);
        }
    }

    void OnStart(){
        isStarting = true;
     }

    void OnEnd(){
        isStarting = false;
     }

}
