using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractMenu : MonoBehaviour
{
    public string NomeNPC;
    public Sprite CharArt;
    private CursorControls controls;
    public Dialogue[] dialogues;
    private Dialogue dialogue;
    [SerializeField] private DialogueManager DialogueManager;
    [SerializeField] private Animator animator;
    private bool isMenuOpen;
    public GameManager gameManager;
    public Camera cameraMenu;
    private void Awake(){
        controls = new CursorControls();
        dialogue = dialogues[0];
    }
    public void OpenMenu(){
        if(gameManager.OpenMenu() == false){
            gameManager.SetMenuBool(true);
            animator.SetBool("MenuOn",gameManager.GetMenuStatus());
        }
    }
    public void CloseMenu(){
        gameManager.CloseMenu();
        animator.SetBool("MenuOn",gameManager.GetMenuStatus());
    }
    public string GetText(){
        return NomeNPC;
    }
    public void triggerDialogue(){
        Debug.Log("Teste1");
        DialogueManager.StartDialogue(dialogue,gameObject);
        CloseMenu();
    }
    public Sprite GetCharArt(){
        return CharArt;
    }
}
