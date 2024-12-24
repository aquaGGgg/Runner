using UnityEngine;
using System;
using System.Collections;

public class DogeComponent : MonoBehaviour
{
    public static event Action OnHarassment;

    private float _jumpForce = 1f;
    private Rigidbody _rb;
    private Animator _anime;
    private BoxCollider _boxCollider;  // Коллайдер персонажа
    private bool _isGrounded;
    private int _poss;

    [SerializeField]
    private bool _isDead;

    // Флаг для отслеживания выполнения корутины
    private bool isCoroutineRunning = false;

    /*----------------------------------------------------------------------------*/

    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _rb = GetComponent<Rigidbody>();
        _anime = GetComponent<Animator>();

        Trigger_Collision_Controller.OnDeath += Dead;
        DeadMenu.OnStart += OnStart;
        MainMenu.OnPlay += OnStart; 
    }

    /*----------------------------------------------------------------------------*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && _isDead == false){
            if (!Physics.Raycast(transform.position - Vector3.down * 0.5f, Vector3.right, 1f))
            {
                _anime.SetBool("RightDodge", true);
                _poss++;
                // Проверяем, выполняется ли корутина
                if (!isCoroutineRunning)
                    StartCoroutine(SmoothMoveLeftRight(1f)); // перемещение вправо
            }
            else OnHarassment?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.A) && _isDead == false){
            if (!Physics.Raycast(transform.position - Vector3.down * 0.5f, Vector3.left, 1f))
            {
                _anime.SetBool("LeftDodge", true);
                _poss--;
                // Проверяем, выполняется ли корутина
                if (!isCoroutineRunning)
                    StartCoroutine(SmoothMoveLeftRight(-1f)); // перемещение влево
            }
            else OnHarassment?.Invoke();
        }

        if ((Input.GetButton("Jump") || Input.GetKeyDown(KeyCode.W)) && _isGrounded && _isDead == false) //@jump
        {
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, CalculateJumpVelocity(), _rb.linearVelocity.z);
        }

        if (Input.GetKeyDown(KeyCode.S) && _isGrounded) // @slide
        {
            _boxCollider.size = _boxCollider.size * 0.5f;
            _boxCollider.center = _boxCollider.center * 0.5f;
            _anime.SetBool("isSliding", true);
            Invoke("NonSliding", 1f);
        }
    }

    /*----------------------------------------------------------------------------*/

    void NonSliding()
    {
        _boxCollider.size = _boxCollider.size * 2f;
        _boxCollider.center = _boxCollider.center * 2f;
        _anime.SetBool("isSliding", false);
    }

    /*----------------------------------------------------------------------------*/

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground")){
            _isGrounded = true;
            _anime.SetBool("isJumping", false);
        }
    }

    /*----------------------------------------------------------------------------*/

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground")){
            _isGrounded = false;
            _anime.SetBool("isJumping", true);
            }
    }

    /*----------------------------------------------------------------------------*/

    float CalculateJumpVelocity()
    {
        return Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * _jumpForce);
    }

    /*----------------------------------------------------------------------------*/

    void Dead()
    {
        _anime.SetBool("isDead", true);
        _isDead = true;
    }

    /*----------------------------------------------------------------------------*/

    void OnStart()
    {
        _poss = 0;
        _anime.SetBool("isDead", false);
        _isDead = false;
        transform.position = new Vector3(0, -0.4f, -3.58f);
    }

    /*----------------------------------------------------------------------------*/

    // Корутина для плавного перемещения влево/вправ
    private IEnumerator SmoothMoveLeftRight(float distance)
    {
        isCoroutineRunning = true; // Устанавливаем флаг, что корутина выполняется

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + Vector3.right * distance; // Направление влево или вправо

        float moveDuration = 0.1f; // Время для перемещения (0.1 секунда)
        float startTime = Time.time;

        while (Time.time - startTime < moveDuration)
        {
            // Вычисляем процент времени (t) и плавно изменяем позицию
            float t = (Time.time - startTime) / moveDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null; // Ждем один кадр
        }

        // Устанавливаем точную конечную позицию и выключаем анимацию доджа        
        _anime.SetBool("RightDodge", false);
        _anime.SetBool("LeftDodge", false);
        transform.position = targetPosition;

        isCoroutineRunning = false; // Сбрасываем флаг после завершения корутины
    }
}
