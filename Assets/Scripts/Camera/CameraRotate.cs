using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour
{
    public float transitionSpeed = 0.5f;      // Скорость плавного перехода

    private Vector3 startlocalPosition ;
    private Quaternion startRotation;
    private Vector3 endlocalPosition  = new Vector3(0,0.122421563f,-0.122315302f);  // Целевая позиция по X
    private Quaternion endRotation = Quaternion.Euler(30f, 0f, 0f);  // Целевой угол поворота

    void Start()
    {
        // Начальные значения
        startlocalPosition  = transform.localPosition ;
        startRotation = transform.rotation;

        MainMenu.OnPlay += OnStart;
        DeadMenu.GoToMenu += OnEnd;
    }  


    void OnStart(){
        StartCoroutine(SmoothTransitionCoroutine());
    }

    void OnEnd(){
        transform.localPosition  = startlocalPosition ;
        transform.rotation = startRotation;
    }

  IEnumerator SmoothTransitionCoroutine()
    {    int i =0;
        while (Vector3.Distance(transform.localPosition , endlocalPosition ) > 1f || Quaternion.Angle(transform.rotation, endRotation) > 1f)
        {
            // Плавное перемещение камеры
            transform.localPosition  = Vector3.Lerp(transform.localPosition , endlocalPosition , transitionSpeed  * Time.deltaTime);

            // Плавное изменение поворота камеры
            transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, transitionSpeed * Time.deltaTime);

            i++;
            Debug.Log(i);
            yield return null; // Ждём один кадр перед продолжением
        }
        transform.localPosition  = endlocalPosition ;
        transform.rotation = endRotation;
    }
}
