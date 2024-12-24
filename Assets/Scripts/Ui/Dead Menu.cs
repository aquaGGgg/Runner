using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System;
using YG;

public class DeadMenu : MonoBehaviour
{    
    public GameObject deadMenu;

    public static event Action OnStart;
    public static event Action GoToMenu;

    public TextMeshProUGUI[] counters; 
    public TextMeshProUGUI allMoney; 
    public GameObject countersOjg;
    public GameObject mainMenu;


    void Start()
    {
        Trigger_Collision_Controller.OnDeath += genMenu;
    }

    void genMenu()
    {
        deadMenu.SetActive(true);
    }


    public void Continue() 
    {
        OnStart?.Invoke();
        deadMenu.SetActive(false);
    }

    public void ToMainMenu()
    {
        GoToMenu?.Invoke();
        countersOjg.SetActive(false);
        mainMenu.SetActive(true);
        deadMenu.SetActive(false);
    }
}