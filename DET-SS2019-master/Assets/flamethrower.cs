using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamethrower : MonoBehaviour
{
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerHealth2>().TakeDamage(5);
            Debug.Log("Damage taken");

        }
        
    }*/ 
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerHealth2>().TakeDamage(5);
            Debug.Log("Damage taken");

        }
    }
}
