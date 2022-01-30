using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    public void NewGame(){
        //FindObjectOfType<AudioManager>().StopAllSounds();
        SceneManager.LoadScene("Game",LoadSceneMode.Single);

    }
    public void ContinueGame(){
        //FindObjectOfType<AudioManager>().StopAllSounds();
        SceneManager.LoadScene("Game",LoadSceneMode.Single);
    }
    public void Settings(){

    }
    public void CreditsGame(){
        
    }
    public void QuitGame(){
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void SetLangPtBr(){
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }
    public void SetLangEn(){
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }
}

