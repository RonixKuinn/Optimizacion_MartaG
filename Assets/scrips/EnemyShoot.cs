using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float EnemymoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * EnemymoveSpeed * Time.deltaTime); 
    }

    private void  OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false); 
        }
    }

    
}
