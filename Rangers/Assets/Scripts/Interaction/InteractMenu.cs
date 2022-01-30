using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMenu : MonoBehaviour
{
    private CursorControls controls;
    [SerializeField] private Animator animator;
    private bool isMenuOpen;
    public GameManager gameManager;
    private void Awake(){
        //gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
