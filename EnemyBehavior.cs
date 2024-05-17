using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float speed = 1.5f;
    private playerbehavior Player;
    private Animator _explosion;
    private AudioSource AudioSource;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        Player = GameObject.Find("Player").GetComponent<playerbehavior>();
        _explosion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        
    }
   void EnemyMovement()
    {
        float rnd = Random.Range(-10, 10);
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= -6.5f)
        {
            transform.position = new Vector3(rnd, 8, 0);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
         
           if (Player != null )
            {
                Player.damage();
            }
            _explosion.SetTrigger("OnEnemyDeath");
            AudioSource.Play();
            speed = 0;
            Destroy(this.gameObject,2.5f);
            
        }
            


        else if (other.tag == "Laser") 
        {
            if (Player != null)
            {
                Player.score(10);
            }
            Destroy(other.gameObject);
            _explosion.SetTrigger("OnEnemyDeath");
            AudioSource.Play();
            speed = 0;
            Destroy(this.gameObject ,2.5f);
            
        }
    }

}
