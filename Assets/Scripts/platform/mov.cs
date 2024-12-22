using UnityEngine;

public class Mov : MonoBehaviour
{
   public GameObject target;  


   private static float _speed = 0f;




   void Start()
   {
          DeadMenu.OnStart += OnStart;
          Trigger_Collision_Controller.OnDeath += Stop;
   }

   void Update()
   {

        if (target == null) return;

        Vector3 direction = (target.transform.position - transform.position).normalized;

        transform.position += direction * _speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            transform.position = target.transform.position;
            bustMovspead();
            Destroy(gameObject);
        }
   }

   private void bustMovspead()  
   {
        _speed += 0.25f;
   }

   void Stop()
   {
          _speed = 0f;
          target = null;
   }

   void OnStart()
   {      
     _speed = 3f;
   }
}
