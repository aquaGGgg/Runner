using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System;

public class MainMenu : MonoBehaviour
{
    public static event Action OnPlay; 


    public TextMeshProUGUI allMoney; 

    public GameObject counters; //счетчики из игрового интерфейса
    public GameObject mainMenu;
    public GameObject seting;
    public GameObject store;
    

    public void OnPlaying(){
        counters.SetActive(true);
        OnPlay?.Invoke();
        mainMenu.SetActive(false);
    }

    public void Setings(){
        if (seting.activeSelf == false){
            seting.SetActive(true);
        } else {
            seting.SetActive(false);
        }
    } 

    public void Store(){
        if (store.activeSelf == false){
            store.SetActive(true);
        } else {
            store.SetActive(false);
        }
    }




}
