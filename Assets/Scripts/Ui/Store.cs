using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;

public class Store : MonoBehaviour
{
    public UnityEvent<int> SwapenScin;
    public TextMeshProUGUI[] skinPriceText;

    public static int coins;
    public TextMeshProUGUI allMonyText;

    private bool[] boughtSkins;
    private int selectedSkinIndex = -1; 
    private int SkinIndex;

    void Start()
    {
        boughtSkins = new bool[skinPriceText.Length];
         if(boughtSkins.Length > 0)
            boughtSkins[0] = true;
        UpdateAllMoneyText();
        UpdateSkinButtonsText();
    }

    void Update()
    {
        UpdateAllMoneyText();
    }

    public void SwapScin(int skinIndex)
    {   
        SkinIndex = skinIndex;

        if (boughtSkins[skinIndex])
        {
            selectedSkinIndex = skinIndex;
            UpdateSkinButtonsText();
            SwapenScin.Invoke(skinIndex);
        }
        else
        {
            int skinPrice = int.Parse(skinPriceText[skinIndex].text);
            if (coins >= skinPrice)
            {
                coins -= skinPrice;
                boughtSkins[skinIndex] = true;
                selectedSkinIndex = skinIndex;
                UpdateAllMoneyText();
                UpdateSkinButtonsText();
                SwapenScin.Invoke(skinIndex);
            } else {
                skinPriceText[skinIndex].text = "Слишком Дорого";
                Invoke("BackPrice", 2f);
            }
        }
    }

    private void UpdateAllMoneyText()
    {
        if (allMonyText != null)
            allMonyText.text = "" + coins;
    }

    private void UpdateSkinButtonsText()
    {
        for (int i = 0; i < skinPriceText.Length; i++)
        {
            if (boughtSkins[i])
            {
                if (selectedSkinIndex == i)
                    UpdateSkinButtonText(i, "Выбрано");
                else
                    UpdateSkinButtonText(i, "Куплено");
            }
            else
                UpdateSkinButtonText(i, "" + skinPriceText[i].text);
        }
    }

    private void UpdateSkinButtonText(int skinIndex, string text)
    {
        skinPriceText[skinIndex].text = text;
    }

        private void BackPrice()
    {
        skinPriceText[SkinIndex].text = "5000";
    }
}