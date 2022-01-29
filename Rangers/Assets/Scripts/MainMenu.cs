using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    public void NewGame(){

    }
    public void ContinueGame(){
        //FindObjectOfType<AudioManager>().StopAllSounds();
        SceneManager.LoadScene("Start",LoadSceneMode.Single);
    }
    public void Settings(){

    }
    public void CreditsGame(){
        
    }
    public void QuitGame(){
        Debug.Log("Quit!");
        Application.Quit();
    }
}
