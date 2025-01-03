    using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public  class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI  text;  
    private int _counter = 0;
    
    void Start(){
        Trigger_Collision_Controller.OnTakeCoin += Coin;
        MainMenu.OnPlay += OnRestart;
    }

    void OnRestart(){
        _counter=0;
        text.text= "0";
    }

    void Coin(){
            _counter++;
            Store.coins++; 
            if(text != null)
            text.text= "" + _counter;
    }
}