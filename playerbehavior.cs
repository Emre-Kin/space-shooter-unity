using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerbehavior : MonoBehaviour
{
    private float _speed = 3.4f;
    public float Horizontalinput;
    public float Verticalinput;
    [SerializeField]
    private GameObject _Laserprefeb;
    private float _firerate = 0.15f;
    private int _lives = 3;
    private Spawnmanager _spawnmanager;
    private bool _istripleshotactive = false;
    [SerializeField]
    private GameObject _tripleshotprefab;
    private bool _isspeedboostactive = false;
    private bool _isshieldactive = false;
    [SerializeField]
    private GameObject _shieldvisulazer;
    private int _score = 0;
    private UI_Manager _Manager;
    GameManager _GameManager;
    [SerializeField]
    private GameObject[] hurt;
    [SerializeField]
    private AudioClip AudioClip;
    private AudioSource AudioSource;
    void Start()
    {
        transform.position = new Vector3(0, -2, 0);
        _GameManager = GameObject.Find("GameManager").AddComponent<GameManager>();
        _Manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _spawnmanager = GameObject.Find("Spawnmanager").GetComponent<Spawnmanager>() ;
        AudioSource = GetComponent<AudioSource>();
        if (_spawnmanager == null)
        {
            Debug.LogError("Spawn manager is null");
        }
        if (_Manager == null) {
            Debug.LogError("UI manager is null");
        }
        if (AudioSource == null) {
            Debug.Log("audıo source not found");
        }
        else
        {
            AudioSource.clip = AudioClip;
        }
    }

    void Update()
    {
        Calcuatemovement();
        Fire();

    }
    void Calcuatemovement()
    {
        
        
        Horizontalinput = Input.GetAxis("Horizontal");
        Verticalinput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * Horizontalinput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * Verticalinput * _speed * Time.deltaTime);
        
        
        float x = transform.position.x;
        float y = transform.position.y;
        
        
        transform.position = new Vector3(x, Mathf.Clamp(y ,-4,0), 0);
        
        
        if (x >= 12 || x <= -12)
        {
            transform.position = new Vector3(-x, y, 0);
        }

    }
    void Fire()
    {
        float y = (float)(transform.position.y + 0.8);
        float x = transform.position.x;
        float nextfire = 0;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextfire) 
        {
            nextfire = _firerate+ Time.time;

            if (_istripleshotactive == true)
            {
                Instantiate(_tripleshotprefab, transform.position, Quaternion.identity);
            }

            else
            {
                Instantiate(_Laserprefeb, new Vector3(x, y, 0), Quaternion.identity);
            }

            AudioSource.Play();

        }
    }
    public void damage()
    {
        if(_isshieldactive == true)
        {
            _isshieldactive = false;
            _shieldvisulazer.SetActive(false);
            return;
        }
        else
        {
            _lives = _lives - 1;
            _Manager.Updatelives(_lives);

        }
        if (_lives == 2)
        {
            hurt[0].SetActive(true);
            hurt[1].SetActive(true);
        }
        else if (_lives == 1)
        {
            hurt[2].SetActive(true);
            hurt[3].SetActive(true); 
            hurt[4].SetActive(true);
            hurt[5].SetActive(true);
        }
        else
        {
            _spawnmanager.Playerdead();
            _GameManager.Gameover();
            Destroy(this.gameObject);
            
        }
    }
    public void İsTripleshotActive()
    {
        _istripleshotactive = true;
        StartCoroutine(Tripleshot());
    }
    public void speedboostactive()
    {
        _isspeedboostactive = true;
        _speed = _speed * 3;
        StartCoroutine(speed());

    }
    public void shieldactive()
    {
        _isshieldactive = true;
        _shieldvisulazer.SetActive(true);
        StartCoroutine(shield());
    }
    IEnumerator Tripleshot()
    {
        yield return new WaitForSeconds(5);
        _istripleshotactive = false;
    }
    IEnumerator speed()
    {
        yield return new WaitForSeconds(5);
        _speed = _speed / 3;
        _isspeedboostactive = false;
    }
    IEnumerator shield()
    {
        yield return new WaitForSeconds(5);
        
        _isshieldactive = false;
        _shieldvisulazer.SetActive(false);

    }
    public void score(int points)
    {
        _score += points;
        _Manager.UpdateScore(_score);
    }
}
