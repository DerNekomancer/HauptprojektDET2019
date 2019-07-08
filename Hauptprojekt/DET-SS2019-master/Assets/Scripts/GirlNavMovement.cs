using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GirlNavMovement : MonoBehaviour
{

    public Transform Player;
    public float moveSpeed = 0.2f;
    public float rotationspeed = 0.2f;
    public Animator anim;
    public Rigidbody rigid;
    public bool VargirlIsAlive = true;
    public int hp = 10;
    public ParticleSystem iceshot;
    public ParticleSystem icelance;
    public GameObject dragon;
    float fireRate = 3.0f;
    float nextFire = 0.0f;

    


    // Start is called before the first frame update
    void Start()
    {

        anim.SetBool("laufen", false);
        anim.SetBool("death", false);
        anim.SetBool("girlIsAlive", true);
        anim.SetBool("sidewalk", false);
        iceshot.emissionRate = 0.0f;
        icelance.emissionRate = 0.0f;
        VargirlIsAlive = true;
        //transform.GetComponent<GirlNavMovement>().enabled = false;


        

    }

    // Update is called once per frame
    void Update()
    {
        /*if (dragon.GetComponent<dragon>().makeGirlsActive)
        {
            GetComponent<GirlNavMovement>().enabled = true;
            
        }*/
        if(!dragon.GetComponent<dragon>().isAlive)
        {
            Destroy(this);
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("GirlNavMovementRaycast");
            
                }
        if (hit.collider != null && hit.collider != Player)
        {
            
            if(transform.position.y < 20)
            {
                Debug.Log("Ich bin hier unten");
            }
            if (transform.position.y >= hit.point.y)
            {
                    transform.position = new Vector3(transform.position.x, hit.point.y+0.1f, transform.position.z);
                    //transform.position += Vector3.down * Time.deltaTime;
                }
            if (transform.position.y <= hit.point.y)
            {
                transform.position = new Vector3(transform.position.x, hit.point.y+0.1f, transform.position.z);
            }



        }
        
        if (VargirlIsAlive)
        {
            if (Vector3.Distance(transform.position, Player.position) < 20)
            {
                transform.LookAt(Player);
            }
            if (Vector3.Distance(transform.position, Player.position) <= 15 && Vector3.Distance(transform.position, Player.position) >= 5)
            {
                //anim.SetBool("sidewalk", false);
                anim.SetBool("laufen", true);
                transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime); //auf uns zu laufen
            }
            if (Vector3.Distance(transform.position, Player.position) < 3)
            {
                anim.SetBool("laufen", true);
                //anim.SetBool("sidewalk", false);
                transform.Translate(0f, 0f, -5f * moveSpeed * Time.deltaTime);
            }
            if (Vector3.Distance(transform.position, Player.position) >= 3 && Vector3.Distance(transform.position, Player.position) < 5)
            {
                //anim.SetBool("laufen", false);
                iceshot.emissionRate = 1.0f;
                icelance.emissionRate = 1.0f;
                anim.SetBool("sidewalk", true);
                transform.Translate(5f * moveSpeed * Time.deltaTime, 0f, 0f);
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    //GameObject.Instantiate(Iceshot, transform.position, Quaternion.identity, transform);
                }
            }
        }
        else
        {
            iceshot.emissionRate = 0.0f;
            icelance.emissionRate = 0.0f;
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.transform != transform)
        {
            this.hp -= 1;
            Debug.Log(hp);
            if (hp <= 0)
            {
                VargirlIsAlive = false;
                iceshot.emissionRate = 0.0f;
                icelance.emissionRate = 0.0f;
                anim.SetBool("girlIsAlive", false);
                anim.SetBool("laufen", false);
            }
        }
        

        
        

    }
}
