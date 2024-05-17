using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text scoretext;
    [SerializeField]
    private Image liveimage;
    [SerializeField]
    private Sprite[] _lives;
    [SerializeField]
    private Text Gameover;
    [SerializeField]
    private Text restart;
    // Start is called before the first frame update
    void Start()
    {
        restart.gameObject.SetActive(false);
        Gameover.gameObject.SetActive(false);   
        scoretext.text = "Score :" + 0;
    }

    public void UpdateScore(int Playerscore)
    {
        scoretext.text = "Score: " + Playerscore.ToString();
    }

    public Sprite[] Get_lives()
    {
        return _lives;
    }

    public void Updatelives(int playerlives)
    {


        liveimage.sprite = _lives[playerlives];
        if (playerlives == 0) 
        {
            GameoverSequance();
        }


    }
    void GameoverSequance()
    {
        restart.gameObject.SetActive(true);
        Gameover.gameObject.SetActive(true);
        StartCoroutine(flickerroutine());
    }
    IEnumerator flickerroutine() {
    while(true)
        {
            Gameover.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            Gameover.text = "";
        }
            }
}
