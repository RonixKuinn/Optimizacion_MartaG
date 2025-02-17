using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public float moveSpeed; 
    public float downwardSpeed; 
    [SerializeField] private Transform _EnemybulletSpawn;
    [SerializeField] private int _ammoType = 1;
    
    


    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        
        transform.Translate(Vector2.down * downwardSpeed * Time.deltaTime);

        
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            moveSpeed *= -1;
            Debug.Log("test");
        } 
    }

    void Shoot()
    {
        GameObject Enemybollet = PoolManager.Instance.GetPooledObjects(_ammoType, _EnemybulletSpawn.position, _EnemybulletSpawn.rotation);

        if (Enemybollet != null)
        {
            Enemybollet.SetActive(true);
        }
        else
        {
            Debug.Log("Pool demasiado pequeno");
        }
    }

    
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(5f); 
        }
    }
}


