using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab; 
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private int _ammoType = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

   /* private void  OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject);
        }
    }*/

    void Shoot()
    {
       GameObject bullet = PoolManager.Instance.GetPooledObjects(_ammoType,_bulletSpawn.position, _bulletSpawn.rotation);

       if(bullet!= null)
       {
        bullet.SetActive(true);
       }
       else
       {
        Debug.Log("Pool demasiado pequeno");
       }
    }

}
