using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] GameObject lvls;
    [SerializeField] GameObject lvlButtonON;
    [SerializeField] GameObject PausePanel;

    public void lvlsSelect(){
         lvls.SetActive(true);
         lvlButtonON.SetActive(false);
         Time.timeScale = 0;
    }

    public void exitLevel(){
        lvls.SetActive(false);
        lvlButtonON.SetActive(true);

        //PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void pause(){
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue(){
        lvlButtonON.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}