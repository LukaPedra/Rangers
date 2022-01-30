using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractMenu : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager;
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
        note = Notes[0];
        Snoop = Snoops[0];
        SnoopLocker = SnoopsLocker[0];
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
        DialogueManager.StartDialogue(dialogue,gameObject,false);
        CloseMenu();
    }
    public void Observe(){
        DialogueManager.StartDialogue(ObserveDialogue,gameObject, true, "Observar");
        CloseMenu();
    }
    public void SnoopBag(){
        DialogueManager.StartDialogue(Snoop,gameObject, true, "Bisbilhotar");
        CloseMenu();
    }
    public void PassNote(){
        DialogueManager.StartDialogue(note, gameObject, false);
        CloseMenu();
    }
    public Sprite GetCharArt(){
        return CharArt;
    }
    public void Sleep(){
        Debug.Log("cima");
        timeManager.Sleep();
        
    }
    public void ChangeDialogue(int n){
        dialogue = dialogues[n];
    }
}
