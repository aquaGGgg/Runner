using UnityEngine;

public class generator : MonoBehaviour
{
    // при переходе на большие префабы цифры нужно заменить

    public GameObject[] paterns;
    public Vector3 currentPosition; // позиция спавна

    void Start()
    {
        currentPosition = transform.position - new Vector3(0,0,-7);
        generate(6); // стартавая генерация
    }

    private void generate(int count){
        for(int i =0; i<count;i++){
        int number   =  Random.Range(0, 4);  // выбор префаба
        Instantiate(paterns[number],currentPosition, Quaternion.identity);
        currentPosition += Vector3.forward * 4;  // кмножение на длинну префаба
        }
    }

    void OnCollisionEnter(Collision collision){ // для создания последующих препятствий
        if(collision.collider.tag != "barer"){ 
        currentPosition = new Vector3(0,0,14); // костыль (задаю корды спавна кждого следуюшего префаба, 2 длинны + половина) 
        generate(1);
        }
    }
}