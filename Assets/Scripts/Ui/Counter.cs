using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public  class Counter : MonoBehaviour
{
    public TextMeshProUGUI  text; 

    private float _counter;
    private float _mytime;
    private bool _isGaiming = true;

    void Start(){
        Trigger_Collision_Controller.OnDeath +=Stop;
        DeadMenu.OnStart += IsGaimng;
        MainMenu.OnPlay += OnStart;
    }

    void Update()
    {
        if(_isGaiming){
        _mytime+=Time.deltaTime;
        _counter+=1 * Time.deltaTime* multiplication();
        }

        if(text != null)
        text.text= "" + (int) _counter;
    }

    float multiplication(){
        return  _mytime/ 2;
    }

    void OnStart(){
        _counter = 0;
        _mytime = 0;
        _isGaiming = true;
    }

    void IsGaimng(){
        _isGaiming = true;
    }

    void Stop(){
        _isGaiming = false;
    }
}
