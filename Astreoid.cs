using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astreoid : MonoBehaviour
{
    private int _speed = 6;
    [SerializeField]
    private GameObject Animation;
    private Spawnmanager spawnmanager;
    // Start is called before the first frame update
    void Start()
    {
       spawnmanager = GameObject.Find("Spawnmanager").GetComponent<Spawnmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser") 
        {
            Destroy(collision.gameObject);
            Instantiate(Animation, transform.position, Quaternion.identity);
            
            spawnmanager.startspawnmanager();
            Destroy(this.gameObject,0.25f);
            
        }
    }
}
