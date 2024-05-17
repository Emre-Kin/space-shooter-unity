using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBhavior : MonoBehaviour
{
    private float speed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Calculationlasermovement();
    }
    void Calculationlasermovement()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y >= 9)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
