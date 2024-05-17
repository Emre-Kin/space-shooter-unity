using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    private float _speed = 2.4f;
    [SerializeField]
    private int _powerid;
    [SerializeField]
    private AudioClip _source;


    // Update is called once per frame
    void Update()
    {
        movementbehaviour();
    }
    void movementbehaviour()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            playerbehavior Player = collision.transform.GetComponent<playerbehavior>();
            AudioSource.PlayClipAtPoint(_source, transform.position);
            if (Player != null)
            {
               switch(_powerid)
                {
                    case 0:
                      Player.İsTripleshotActive();
                        break;
                    case 1:
                        Player.speedboostactive();
                        break;
                    case 2:
                        Player.shieldactive();
                        break;
                    default:
                        Debug.Log("Default case");
                        break;

                }

                
            }

            Destroy(this.gameObject);

        }
    }
}
