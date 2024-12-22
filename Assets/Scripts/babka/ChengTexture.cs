using UnityEngine;

public class ChengTexture : MonoBehaviour
{
    public Material targetMaterial; 
    public Texture2D[] newTexture; 

    void Start()
    {

        ChangeBasemap(0);
    }

    public void ChangeBasemap(int i)
    {
       
            targetMaterial.SetTexture("_BaseMap", newTexture[i]);
    }
}
