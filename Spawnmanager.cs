using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawnmanager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyprefeb;
    [SerializeField]
    private GameObject Enemycontainer;
    [SerializeField]
    private GameObject tripleshot;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject speed;
    private bool spawn = true;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void startspawnmanager()
    {
        StartCoroutine(Spawnrate());
        StartCoroutine(Powerupspawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playerdead()
    {
        spawn = false;
        Destroy(Enemycontainer);
    }

    IEnumerator Spawnrate()
    {
        yield return new WaitForSeconds(3);
        while (spawn == true)
        {
            float rnd = Random.Range(-9, 9);
            GameObject newEnemy =  Instantiate(enemyprefeb, new Vector3(rnd, 8, 0) , Quaternion.identity);
            newEnemy.transform.parent = Enemycontainer.transform;
            yield return new WaitForSeconds(5f);
            
        }
    }
    IEnumerator Powerupspawn()
    {
        yield return new WaitForSeconds(5);
        while (spawn == true)
        {
            int powerup = Random.Range(0, 3);
            float rn = Random.Range(5, 8);
            float rnd = Random.Range(-9, 9);
            
            if (powerup == 1) {
                Instantiate(tripleshot, new Vector3(rnd, 8, 0), Quaternion.identity);
            }
            else if (powerup == 2)
            {
                Instantiate(speed, new Vector3(rnd, 8, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(shield, new Vector3(rnd, 8, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(rn);
        }

    }
}
