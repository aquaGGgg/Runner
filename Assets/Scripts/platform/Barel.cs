using UnityEngine;

public class Barel : MonoBehaviour
{
    
   public GameObject target;  

   private static float _speed = 0.5f;

    void Update()
    {
         Vector3 direction = (target.transform.position - transform.position).normalized;

        transform.position += direction * _speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            transform.position = target.transform.position;
            Destroy(gameObject);
        }
    }
}
