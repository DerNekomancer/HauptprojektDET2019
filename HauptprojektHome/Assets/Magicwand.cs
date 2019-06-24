using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magicwand : MonoBehaviour
{
    
    public ParticleSystem magicFirestream;
    public GameObject magicFireball;
    public GameObject playerMagicWand;
    public Vector3 playerMagicWandPos;
    public GameObject MagicWandPlayer;
    // AudioClip spell1;
    // Start is called before the first frame update
    void Start()
    {
        
        playerMagicWandPos = playerMagicWand.transform.position;
        Debug.Log(playerMagicWandPos);
        magicFirestream.emissionRate = 0.0f;
       // GameObject.Find("FlameCollider").GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyUp(KeyCode.Alpha0) || Input.GetKey(KeyCode.Alpha0))
        {
            //GameObject.Find("FlameCollider").GetComponent<Collider>().enabled = false;
        }
        if (Input.GetMouseButton(0)) 
        {
            Debug.Log("Fireeeeee");
            magicFirestream.emissionRate = 100.0f;
            //GameObject.Find("FlameCollider").GetComponent<Collider>().enabled = true;
                
        }
        
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(magicFireball, playerMagicWandPos, transform.rotation, playerMagicWand.transform);
            magicFirestream.GetComponent<BoxCollider>().enabled = false;
        }
        else 
        {
            magicFirestream.emissionRate = 0.0f;
           // GameObject.Find("FlameCollider").GetComponent<Collider>().enabled = false;
        }
       /* if(Mathf.Abs(magicFireball.transform.position.x - MagicWandPlayer.transform.position.x) >= Mathf.Abs(5))
        {
            //Destroy(magicFireball);
        }*/
    }
  


}
