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
        KadukiMaxSpawn = 1;
        KadukiSpawnCounter = 0;
        alternativeCounter = 0;
        phase2Finished = false;
        wantedPosition2 = new Vector3(9f, 81f, -7f);



    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            
            if (phase1)
            {


                if (Input.GetKeyDown(KeyCode.X))
                {
                    Instantiate(girl, transform.position, Quaternion.identity, transform);
                }
                if (Vector3.Distance(transform.position, Player.position) < 20)
                {
                    if (transform.position.x.Equals(Player.transform.position.x+3)|| transform.position.x.Equals(Player.transform.position.x - 3))
                    {
                        Debug.Log("ich steh scheiße");
                        Vector3 wantedPosition3 = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                        //transform.position = Vector3.Lerp(transform.position, wantedPosition3, Time.deltaTime * lerpSpeed);
                        transform.position += Vector3.back * Time.deltaTime;
                    }
                    if (Vector3.Distance(transform.position, Player.position) < 3)
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
                            //this.GetComponent<BoxCollider>().transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime);
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
            else if(phase2)
            {
                dragonFirestream.emissionRate = 0.0f;
                resetAnimBool();
                
                //Debug.Log("phase 2 entered");
                Renderer rend = GetComponent<Renderer>();                
                rend.material.SetColor("_Color", Color.yellow);
                rend.materials[1].color = Color.black;// ("secondaryColor", Color.red);
                
                
                lerpSpeed = 0.5f;
                if (!phase2Finished && transform.position.y < oldyPos + 1 )
                {
                    Vector3 wantedPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * lerpSpeed);
                }
                else
                {
                    Debug.Log("Kek before gamefind");
                    Debug.Log(GameObject.FindGameObjectsWithTag("RedKaduki").Length);
                    if (alternativeCounter < 1)
                    {
                        if (GameObject.FindGameObjectsWithTag("RedKaduki").Length.Equals(1))
                        {
                            Debug.Log("Kek");
                            for (int i = 0; i < KadukiMaxSpawn; i++)
                            {
                                Instantiate(girl, dragonHead.transform.position, transform.rotation, dragonHead.transform);
                                KadukiSpawnCounter++;
                                Debug.Log("kadukispawncounter: " + KadukiSpawnCounter);

                            }
                            alternativeCounter++;
                            Debug.Log("alternative counter: " +alternativeCounter);
                        }
                        else
                        {
                           
                            Debug.Log("Not length 1");
                        }
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, wantedPosition2, Time.deltaTime * 0.5f);
                        phase2Finished = true;
                        Debug.Log(phase3);
                        phase2 = false;
                        phase3 = true;
                        Debug.Log(phase3);
                    }
                    




                    //while (KadukiSpawnCounter < 3)
                    // {


                    /* while (GameObject.FindGameObjectsWithTag("RedKaduki").Length.Equals(0))
                     {
                         Debug.Log("Spawning kadukis");
                         Instantiate(girl, transform.position, transform.rotation, transform);


                     }

                     KadukiSpawnCounter++;
                     Debug.Log("Kaduki Spawn Counter: " + KadukiSpawnCounter); */

                    // }
                    //Vector3 wantedPosition2 = new Vector3(transform.position.x, transform.position.y -3 , transform.position.z);
                    //transform.position = Vector3.Lerp(transform.position, wantedPosition2, Time.deltaTime * lerpSpeed);

                    /* if (transform.position.Equals(wantedPosition2))
                     {
                         phase2 = false;
                         phase3 = true;
                     } */
                }

            }
               
            
            else if(phase3)
            {
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
                    if(transform.position.x.Equals(Player.transform.position.x))
                    {
                        Debug.Log("ich steh scheiße,phase 3");
                        Vector3 wantedPosition3 = new Vector3(transform.position.x+2,transform.position.y,transform.position.z); 
                        //transform.position = Vector3.Lerp(transform.position, wantedPosition3, Time.deltaTime * lerpSpeed);
                        transform.position += Vector3.back * Time.deltaTime;
                    }
                    if (Vector3.Distance(transform.position, Player.position) < 2)
                    {
                        //transform.position = Vector2.MoveTowards(transform.position, Player.position, -1 * 2 * Time.deltaTime);
                        transform.Translate(1f, 1f, -1 * 5f * moveSpeed * Time.deltaTime);
                        this.GetComponent<BoxCollider>().transform.Translate(0f, 0f, -1 * 5f * moveSpeed * Time.deltaTime);

                    }
                    Vector3 headvector = head.transform.position;
                    transform.LookAt(Player);
                    if (anim.GetBool("isIdle") == false)             //flying
                    {
                        if (Vector3.Distance(transform.position, Player.position) < 4)
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
        else
        {
            dragonFirestream.emissionRate = 0.0f;
        }
    }

    public void resetAnimBool()
    {
        anim.SetBool("flyAttack", false);
       
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
