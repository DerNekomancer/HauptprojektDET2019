using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dragon : MonoBehaviour
{
    public Transform Player;
    public Animator anim;
    float moveSpeed = 0.2f;
    int timePassed = 0;
    public GameObject flamethrow;
    public GameObject head;
    int counter = 0;
    int waitTime = 2;
    //GameObject instantiatedFlamebreath;
    int maxCounter = 1;
    public ParticleSystem dragonFirestream;
    public int dragonMaxHP = 1000;
    public int dragonCurrentHp;
    public SimpleHealthBar dragonHealthbar;
    public bool isAlive = true;


    // Start is called before the first frame update
    void Start()
    {
         anim.SetBool("Fly", true);
        isAlive = true;
        dragonCurrentHp = dragonMaxHP;
        dragonHealthbar.UpdateBar(dragonCurrentHp,dragonMaxHP);
        Debug.Log(dragonCurrentHp);
        dragonFirestream.emissionRate = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {


            if (Vector3.Distance(transform.position, Player.position) < 20)
            {
                if(Vector3.Distance(transform.position,Player.position)< 3)
                {
                    //transform.position = Vector2.MoveTowards(transform.position, Player.position, -1 * 2 * Time.deltaTime);
                    transform.Translate(1f, 1f, -1 * 5f * moveSpeed * Time.deltaTime);
                    this.GetComponent<BoxCollider>().transform.Translate(0f, 0f, -1 * 5f * moveSpeed * Time.deltaTime);
                    
                }
                Vector3 headvector = head.transform.position;
                transform.LookAt(Player);
                if (anim.GetBool("isIdle") == false)             //flying
                {
                    if (Vector3.Distance(transform.position, Player.position) < 6)
                    {
                        anim.SetBool("flyAttack", true);
                        if (anim.GetBool("flyAttack") == true)
                        {
                            dragonFirestream.emissionRate = 50.0f;
                            /*if (instantiatedFlamebreath == null)
                            {
                            
                                //instantiatedFlamebreath = Instantiate(flamethrow, headvector, transform.rotation, head.transform);
                                Debug.Log("instantiated flamebreath");
                                counter++;
                                Debug.Log("counter: " + counter);
                            } */
                        }

                        if (Input.GetKeyDown(KeyCode.M))
                        {
                            dragonFirestream.emissionRate = 0.0f;
                        }

                    }
                    if (Vector3.Distance(transform.position, Player.position) > 10)
                    {

                        if (Input.GetKeyDown(KeyCode.M))
                        {
                            dragonFirestream.emissionRate = 0.0f;
                        }

                        anim.SetBool("flyAttack", false);
                        //if (counter >= 1)
                        //{
                        dragonFirestream.emissionRate = 0.0f;
                        //if (instantiatedFlamebreath != null) {  Destroy(instantiatedFlamebreath); }
                        //}


                    }
                    if (Vector3.Distance(transform.position, Player.position) <= 15 && Vector3.Distance(transform.position, Player.position) > 7)
                    {
                        transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime);
                        this.GetComponent<BoxCollider>().transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime);
                    }

                }
                else                                             //on the ground
                {
                    if (Vector3.Distance(transform.position, Player.position) < 8)
                    {
                        anim.SetBool("standAttack", true);
                        anim.SetBool("walking", false);
                    }
                    if (Vector3.Distance(transform.position, Player.position) <= 15 && Vector3.Distance(transform.position, Player.position) > 7)
                    {
                        anim.SetBool("walking", true);
                        transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime);
                        this.GetComponent<BoxCollider>().transform.Translate(Vector3.down * Time.deltaTime * 5);
                    }
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    anim.SetBool("isIdle", false);
                }
                else if (Input.GetKeyDown(KeyCode.O))
                {
                    anim.SetBool("isIdle", true);
                }
            }
            
        }
    }
    private void OnParticleCollision(GameObject other)
    {

        if (other.tag == "Player")
        {
            if (dragonCurrentHp >= 0)
            {
                Debug.Log("Dragon hit");
                dragonTakeDamage(25);
                dragonHealthbar.UpdateBar(dragonCurrentHp, dragonMaxHP);
                
               // anim.SetBool("dragonIsAlive", false);
                //anim.Play("Vox_Dragon_Dead");
            }
            if(dragonCurrentHp <= 0)
            {
                Debug.Log("dragon dead");
                //Destroy(gameObject);
                isAlive = false;
                anim.SetBool("dragonIsAlive", false);
               // anim.Play("Vox_Dragon_Dead");
                this.GetComponent<BoxCollider>().enabled = false;
            }

            Debug.Log(dragonCurrentHp);


        }
    }

    


    public void dragonTakeDamage(int amount)
    {
        dragonCurrentHp -= amount;
    }
}
