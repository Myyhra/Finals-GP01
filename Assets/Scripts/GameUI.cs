using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] GameObject win;
    [SerializeField] GameObject dead;
    [SerializeField] GameObject deadPanel;
    [SerializeField] GameObject BlueOrb;
    [SerializeField] TextMeshProUGUI blueOrbText;
    [SerializeField] GameObject Coin;
    [SerializeField] TextMeshProUGUI CoinText;
    [SerializeField] GameObject[] pick;
    public bool playSound;
    void Update()
    {
        if(manager.win && playSound)
        {
            win.SetActive(true);
            foreach(GameObject pick in pick)
            {
                pick.SetActive(true);
            }
        }
        if(manager.dead)
        {
            deadPanel.SetActive(true);
            dead.SetActive(true);
            foreach(GameObject pick in pick)
            {
                pick.SetActive(true);
            }
        }

        blueOrbText.text = manager.OrbCount.ToString();
        CoinText.text = manager.coinCount.ToString();

    }
    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }


}
