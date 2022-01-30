using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMenu : MonoBehaviour
{
    private CursorControls controls;
    [SerializeField] private Animator animator;
    private bool isMenuOpen;
    private void Awake(){
        controls = new CursorControls();
    }
    public void OpenMenu(){
        isMenuOpen = true;
        animator.SetBool("MenuOn",isMenuOpen);
    }
    public void CloseMenu(){
        isMenuOpen = false;
        animator.SetBool("MenuOn",isMenuOpen);
    }
}
