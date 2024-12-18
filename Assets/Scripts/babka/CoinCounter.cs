using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public  class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI  text;  
    private int _counter = 0;

    void Start(){
        Trigger_Collision_Controller.OnTakeCoin +=Coin;
        DeadMenu.OnStart +=OnRestart;
    }

    void OnRestart(){      
        _counter=0;
    }
    void Coin(){
            _counter++;
            if(text != null)
            text.text= "" + _counter;
    }


}