using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System;

public class MusickManedger : MonoBehaviour
{
    public AudioSource soundEfect;  // для настроек звука
    public AudioSource music;       //


    public Sprite[] soundImages;   //   
    public Image musicButtonImage; //  для замены картинок на переключателях звука
    public Image soundButtonImage; //  
    
    public TextMeshProUGUI textSoundEfect;  // для изменеиня текстов
    public TextMeshProUGUI textMusic;       //

    private bool isMusicOn = true; 
    private bool isSoundOn = true; 

        public void Music(){
        isMusicOn = !isMusicOn;
        music.mute = !isMusicOn;
        UpdateMusicUI();
    }

    public void SoundEfects(){
        isSoundOn = !isSoundOn; 
        soundEfect.mute = !isSoundOn;
        UpdateSoundUI();
    }

    /*------------------------------------------------------------------------------*/

    private void UpdateMusicUI()
    {
        if (musicButtonImage != null)
        {
          musicButtonImage.sprite = isMusicOn ? soundImages[0] : soundImages[1]; 
        }
        if(textMusic != null)
        {
            textMusic.text = isMusicOn ? "Выкл. музыка" : "Вкл. музыка";
        }
    }
    private void UpdateSoundUI()
    {
        if (soundButtonImage != null)
        {
            soundButtonImage.sprite = isSoundOn ? soundImages[0] : soundImages[1];
        }
         if (textSoundEfect != null)
        {
            textSoundEfect.text = isSoundOn ? "Выкл. звук" : "Вкл. звук";
        }
    }
    private void Start()
    {
      UpdateSoundUI();
      UpdateMusicUI();
    }
}
