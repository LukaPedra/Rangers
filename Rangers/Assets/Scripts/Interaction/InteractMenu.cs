using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMenu : MonoBehaviour
{
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
}
