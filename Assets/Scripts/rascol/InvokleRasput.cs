using UnityEngine;
using System.Collections;

public class InvokleRasput : MonoBehaviour
{
    public GameObject babka;

    private bool isHaras;
    private float timer;

    void Start()
    {
        DeadMenu.OnStart += OnHaras;
        MainMenu.OnPlay += OnHaras; // 
        DogeComponent.OnHarassment += OnHaras;        
        Trigger_Collision_Controller.OnDeath +=OnHaras;
    }

    void Update(){

        
        if(isHaras)
        Haras();
        if(!isHaras)
        transform.position = babka.transform.position - Vector3.forward*3;
    }

    void OnHaras(){
        isHaras = true;
        Haras();
        if(isHaras)
        Invoke("StopHaras", 5);
    }


    void StopHaras(){
        isHaras = false;
    }


    void Haras(){
        StartCoroutine(SmoothMoveCoroutine());
    }


    private IEnumerator SmoothMoveCoroutine()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = babka.transform.position - Vector3.forward;

        // Вычисляем длину пути
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        if (journeyLength == 0f)
        {
            yield break;  // Если длина пути равна нулю, выходим из корутины
        }

        // Время на завершение движения
        float moveDuration = 0.2f;  // Общее время на движение
        float startTime = Time.time;  // Время начала движения

        while (Time.time - startTime < moveDuration)
        {
            // Интерполируем позицию с использованием времени
            float t = (Time.time - startTime) / moveDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            // Плавность перемещения
            yield return null;  // Ожидаем один кадр
        }

        // Устанавливаем конечную позицию точно после завершения
        transform.position = targetPosition;
    }
}
