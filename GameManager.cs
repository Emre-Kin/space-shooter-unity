using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _isgameover = false;


    private void Update()
    {
        if (_isgameover == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        else if (_isgameover == true && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Gameover()
    {
        _isgameover=true;
    }
}
