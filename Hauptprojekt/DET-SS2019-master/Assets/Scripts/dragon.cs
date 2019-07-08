using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public int dragonMaxHP = 20000;
    public int dragonCurrentHp;
    public SimpleHealthBar dragonHealthbar;
    public bool isAlive = true;
    public bool phase1,phase2,phase3;
    public int dragonDamage;
    public GameObject girl;
    public float lerpSpeed;
    float oldyPos;
    public int KadukiMaxSpawn;
    public int KadukiSpawnCounter;
    int alternativeCounter;
    public bool phase2Finished;
    Vector3 wantedPosition2;
    public GameObject dragonHead;
    public GameObject girl2;
    public GameObject girl3;
    public bool makeGirlsActive;
    public int blondKadukiCounter;


    // Start is called before the first frame update
    void Start()
    {
        // anim.SetBool("Fly", true);
        dragonFirestream.emissionRate = 0.0f;
        phase1 = true;
        phase2 = false;
        phase3 = false;
        isAlive = true;
        dragonDamage = 10;
        anim.SetBool("dragonIsAlive", true);
        dragonMaxHP = 10000;
        dragonCurrentHp = dragonMaxHP;
        dragonHealthbar.UpdateBar(dragonMaxHP, dragonMaxHP);
        oldyPos = (transform.position.y);
        KadukiMaxSpawn = 2;
        KadukiSpawnCounter = 0;
        alternativeCounter = 0;
        phase2Finished = false;
        wantedPosition2 = new Vector3(9f, 81f, -7f);
        int counter = 0;
        makeGirlsActive = false;
        blondKadukiCounter = 0;





}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            Destroy(girl);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Destroy(girl2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Destroy(girl3);

        }
        if (isAlive)
        {

            if (phase1)
            {


                if (Input.GetKeyDown(KeyCode.X))
                {

                    Debug.Log("kek before raycast");
                    // Does the ray intersect any objects excluding the player layer

                    RaycastHit hit;
                    //RaycastHit hit = Physics.Raycast(new Vector3(Player.transform.position.x,Player.transform.position.y+10,Player.transform.position.z), -Vector2.down);
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
                    {
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                        Debug.Log("Did Hit");
                    }
                    if (hit.collider != null && hit.collider != Player)
                    {
                        Debug.Log("surface: " + hit.point);
                        float rnd1 = RandomNumber(1, 3);
                        Instantiate(girl, new Vector3(Player.position.x + rnd1, hit.point.y, Player.position.z), transform.rotation, transform);

                    }


                    //     int rnd1 = RandomNumber(0, 3);
                    //Instantiate(girl, new Vector3(Player.position.x + rnd1, Player.position.y + 5, Player.position.z), transform.rotation, Player);
                }
                
                if (Vector3.Distance(transform.position, Player.position) < 20)
                {

                   
                     if(Vector3.Distance(transform.position,Player.transform.position) < 15 && blondKadukiCounter != 1)
                    {
                        RaycastHit hit5;
                        if (Physics.Raycast(new Vector3(transform.position.x+1,transform.position.y,transform.position.z+3), transform.TransformDirection(Vector3.down), out hit5, Mathf.Infinity))
                        {

                            Debug.Log("Did Hit");
                        }
                        if (hit5.collider != null && hit5.collider != Player)
                        {
                            Debug.Log("surface5: " + hit5.point);
                            //int rnd1 = RandomNumber(0, 3);
                            //Instantiate(girl, new Vector3(Player.position.x + rnd1, hit.point.y, Player.position.z), transform.rotation, transform);

                        }
                        Instantiate(girl2, new Vector3(transform.position.x+1, hit5.point.y, transform.position.z + 2), transform.rotation, transform);
                        blondKadukiCounter++;
                    }
                    Vector3 headvector = head.transform.position;
                    transform.LookAt(Player);
                    if (anim.GetBool("isIdle") == false)             //flying
                    {
                        if (Vector3.Distance(transform.position, Player.position) < 7)
                        {
                            if (Vector3.Distance(transform.position, Player.position) < 5)
                            {
                                transform.position += Vector3.back * Time.deltaTime * 2;
                            }
                            anim.SetBool("flyAttack", true);
                            if (anim.GetBool("flyAttack") == true)
                            {
                                dragonFirestream.emissionRate = 50.0f;
                               
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
            else if (phase2)
            {
                if(Input.GetKeyDown(KeyCode.K))
                {
                    phase2Finished = true;
                    phase2 = false;
                    phase3 = true;
                }
                dragonFirestream.emissionRate = 0.0f;
                resetAnimBool();

                //Debug.Log("phase 2 entered");
                Renderer rend = GetComponent<Renderer>();
                rend.material.SetColor("_Color", Color.yellow);
                rend.materials[1].color = Color.black;// ("secondaryColor", Color.red);


                lerpSpeed = 1f;
                if (!phase2Finished && transform.position.y < oldyPos + 1)
                {
                    Vector3 wantedPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * lerpSpeed);
                }
                else
                {
                    Debug.Log("Kek before gamefind");
                    Debug.Log(GameObject.FindGameObjectsWithTag("BlackKaduki").Length);
                    RaycastHit hit;


                    if (alternativeCounter < 3) //increase this
                    {
                        if (GameObject.FindGameObjectsWithTag("BlackKaduki").Length.Equals(1)) //change to equals(1) if going back to RedKadukis
                        {
                            if (Physics.Raycast(Player.transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
                            {

                                Debug.Log("Did Hit");
                            }
                            if (hit.collider != null && hit.collider != Player)
                            {
                                Debug.Log("surface: " + hit.point);
                                //int rnd1 = RandomNumber(0, 3);
                                //Instantiate(girl, new Vector3(Player.position.x + rnd1, hit.point.y, Player.position.z), transform.rotation, transform);

                            }
                            Debug.Log("Kek");
                            //girl.GetComponent<GirlNavMovement>().enabled = true;
                            for (int i = 0; i < KadukiMaxSpawn; i++)
                            {
                                Debug.Log("spawning kadukis");
                                float rnd1 = RandomNumber(1, 3);
                                
                                Instantiate(girl, new Vector3(Player.position.x + rnd1, hit.point.y, Player.position.z + rnd1), transform.rotation, transform);
                                
                                KadukiSpawnCounter++;
                                Debug.Log("kadukispawncounter: " + KadukiSpawnCounter);

                            }
                            
                            alternativeCounter++;
                            Debug.Log("alternative counter: " + alternativeCounter);
                        }
                        else
                        {

                            Debug.Log("Not length 1");
                        }
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, wantedPosition2, Time.deltaTime * 0.5f);
                        Debug.Log(phase3);
                        phase2Finished = true;
                        phase2 = false;
                        phase3 = true;

                    }

                }


            }
            else if (phase3)
            {
                transform.position = Vector3.Lerp(transform.position, wantedPosition2, Time.deltaTime * 1f);
                resetAnimBool();

                Debug.Log("phase 3 entered");
                Renderer rend = GetComponent<Renderer>();
                rend.material.SetColor("_Color", Color.yellow);
                rend.materials[1].color = Color.red;// ("secondaryColor", Color.red);
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Instantiate(girl, transform.position, Quaternion.identity, transform);
                }

                if (Vector3.Distance(transform.position, Player.position) < 20)
                {
                    Debug.Log("CCCCCCCCCCCCCC");
                    /* if (Vector3.Distance(transform.position, Player.position) < 3)
                     {
                         //transform.position = Vector2.MoveTowards(transform.position, Player.position, -1 * 2 * Time.deltaTime);
                         // transform.Translate(1f, 1f, -1 * 5f * moveSpeed * Time.deltaTime);
                         transform.position += Vector3.back * Time.deltaTime * 2;
                        // this.GetComponent<BoxCollider>().transform.Translate(0f, 0f, -1 * 5f * moveSpeed * Time.deltaTime);

                     } */
                    Vector3 headvector = head.transform.position;
                    transform.LookAt(Player);
                    if (anim.GetBool("isIdle") == false)             //flying
                    {
                        if (Vector3.Distance(transform.position, Player.position) < 12)
                        {
                            if (Vector3.Distance(transform.position, Player.position) < 4)
                            {
                                transform.position += Vector3.back * Time.deltaTime * 2;
                            }
                            else
                            {
                                if(Vector3.Distance(transform.position, Player.position) < 6)
                                {
                                    anim.SetBool("flyAttack", true);
                                }                               
                                if (anim.GetBool("flyAttack") == true)
                                {
                                    RaycastHit hit3;
                                    if (Physics.Raycast(Player.transform.position, transform.TransformDirection(Vector3.down), out hit3, Mathf.Infinity))
                                    {

                                        Debug.Log("DDDDDDDDDDDD");
                                    }
                                    if (hit3.collider != null && hit3.collider != Player)
                                    {
                                        Debug.Log("EEEEEEEEE: " + hit3.point);
                                        //int rnd1 = RandomNumber(0, 3);
                                        //Instantiate(girl, new Vector3(Player.position.x + rnd1, hit.point.y, Player.position.z), transform.rotation, transform);

                                    }
                                    dragonFirestream.emissionRate = 50.0f;
                                    
                                    if(counter == 0)
                                    {
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Instantiate(girl3, new Vector3(Player.transform.position.x + 0.5f * counter, hit3.point.y, Player.position.z + 0.5f*counter), transform.rotation, transform);
                                            counter++;
                                        }
                                    }
                                    

                                }

                                if (Input.GetKeyDown(KeyCode.M))
                                {
                                    dragonFirestream.emissionRate = 0.0f;
                                }
                            }

                        }
                        if (Vector3.Distance(transform.position, Player.position) > 12)
                        {

                            if (Input.GetKeyDown(KeyCode.M))
                            {
                                dragonFirestream.emissionRate = 0.0f;
                            }

                            anim.SetBool("flyAttack", false);
                            dragonFirestream.emissionRate = 0.0f;
                            transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * 0.5f);



                        }
                        /*if (Vector3.Distance(transform.position, Player.position) <= 12 && Vector3.Distance(transform.position, Player.position) > 7)
                        {
                            transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime);
                            //this.GetComponent<BoxCollider>().transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime);
                        } */

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
    }
    

    public void resetAnimBool()
    {
        anim.SetBool("flyAttack", false);
       
    }
    public float RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    private void OnParticleCollision(GameObject other)
    {

        if (other.tag == "Player")
        {
            if(phase1)
            {
                if (dragonCurrentHp >= 6666)
                {
                    Debug.Log("Dragon hit,phase 1");
                    dragonTakeDamage(45);
                    dragonHealthbar.UpdateBar(dragonCurrentHp, dragonMaxHP);

                    // anim.SetBool("dragonIsAlive", false);
                    //anim.Play("Vox_Dragon_Dead");
                }
                else
                {

                    //Color newcol = new Color(0f, 0f, 0f, 0f);
                    //gameObject.GetComponent<SkinnedMeshRenderer>().material.color = newcol;

                    /*Renderer rend = GetComponent<Renderer>();
                    rend.material.shader = Shader.Find("_Color");
                    rend.material.SetColor("_Color", Color.green);

                    rend.material.shader = Shader.Find("Specular");
                    rend.material.SetColor("_SpecColor", Color.red);*/
                    Debug.Log("entering phase2");
                    phase1 = false;
                    phase2 = true;
                }
            }
            else if (phase2)
            {
                if(alternativeCounter >= 3)
                {
                    phase2 = false;
                    phase3 = true;
                    
                }
                /*if (dragonCurrentHp >= 3333)
                {
                    Debug.Log("Dragon hit");
                    dragonTakeDamage(25);
                    dragonHealthbar.UpdateBar(dragonCurrentHp, dragonMaxHP);

                    // anim.SetBool("dragonIsAlive", false);
                    //anim.Play("Vox_Dragon_Dead");
                }
                else
                {
                    phase2 = false;
                    phase3 = true;
                } */
            }
            else if(phase3)
            {
                dragonDamage = 20;
                if (dragonCurrentHp >= 0)
                {
                    Debug.Log("Dragon hit");
                    dragonTakeDamage(70);
                    dragonHealthbar.UpdateBar(dragonCurrentHp, dragonMaxHP);

                    // anim.SetBool("dragonIsAlive", false);
                    //anim.Play("Vox_Dragon_Dead");
                }
                if (dragonCurrentHp <= 0)
                {
                    Debug.Log("dragon dead");
                    //Destroy(gameObject);
                    isAlive = false;
                    anim.SetBool("dragonIsAlive", false);
                    dragonFirestream.emissionRate = 0.0f;
                    // anim.Play("Vox_Dragon_Dead");
                    this.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }       
            Debug.Log(dragonCurrentHp);      
    }

    
    public int getDamage()
    {
        return this.dragonDamage;
    }
    public void setDamage(int dmg)
    {
        this.dragonDamage = dmg;
    }
    
    public void dragonTakeDamage(int amount)
    {
        dragonCurrentHp -= amount;

            
    }
}
