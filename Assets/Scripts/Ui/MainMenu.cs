using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System;

public class MainMenu : MonoBehaviour
{


    public static event Action OnPlay;

    public GameObject audioSource;
    public TextMeshProUGUI sound;

    public TextMeshProUGUI allMoney; 
    public GameObject counters;
    public GameObject mainMenu;


    public void OnPlaying(){
        counters.SetActive(true);
        OnPlay?.Invoke();
        mainMenu.SetActive(false);
    }


    public void Sound(){

        if (audioSource.activeSelf == false){
           audioSource.SetActive(true);
           //sound.text = "Звук выкл.";
        } 
        else{
           audioSource.SetActive(false);
           // sound.text = "Звук вкл.";
           }
    }



}
