using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetsGameMaster : MonoBehaviour
{

    public GameObject restartPanel;
    public AudioSource deathSoundEffect;
    public AudioSource PopSoundEffect;
    public Text timerDisplay;
    public bool hasLost;
    public float timer = 10;

    public void Update()
    {
        if (hasLost == false)
        {
            timerDisplay.text =  "Time Left : " + timer.ToString("F0");
        }
        if(timer <= 0)
        {
            //go to next level
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) + 1;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }


    public void GoToGameScene()
    {
        SceneManager.LoadScene("PlanetsEx");

    }

    void DelayRestartPanel()
    {
        restartPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        hasLost = true;
        Invoke("DelayRestartPanel", 1.5f);
    }
    public void PlaySound(string sound)
    {
        if(sound == "DeathSoundEffect")
        {
            deathSoundEffect.Play();
        }
        else if (sound == "PopSoundEffect")
        {
            PopSoundEffect.Play();
        }

    }
    
    
    
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
}
