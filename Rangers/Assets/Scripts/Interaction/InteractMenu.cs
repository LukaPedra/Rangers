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
    public Dialogue[] Notes;
    private Dialogue note;
    public Dialogue[] Snoops;
    private Dialogue Snoop;
    public Dialogue[] SnoopsLocker;
    private Dialogue SnoopLocker;
    public Dialogue ObserveDialogue;
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
        DialogueManager.StartDialogue(dialogue,gameObject);
        CloseMenu();
    }
    public void Observe(){

        CloseMenu();
    }
    public void SnoopBag(){

        CloseMenu();
    }
    public void PassNote(){

        CloseMenu();
    }
    public Sprite GetCharArt(){
        return CharArt;
    }
    public void ChangeDialogue(int n){
        dialogue = dialogues[n];
    }
}
