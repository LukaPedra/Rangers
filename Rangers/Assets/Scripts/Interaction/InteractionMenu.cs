using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionMenu : MonoBehaviour
{
    private CursorControls controls;
    private void Awake() {
        controls = new CursorControls();
    }
    private void OnEnable(){
        controls.Enable();
    }
    private void OnDisable() {
        controls.Disable();
    }
    private void Start(){
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }
    private void StartedClick(){

    }
    private void EndedClick(){
        DetectObject();
    }
    private void Update() {
        //Vector3 mousePos = Mouse.current.po
        //mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = Camera.main.nearClipPlane;
        //transform.position = worldPosition;
    }

    private void DetectObject(){
        Ray ray = Camera.main.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());

        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if (hit2D.collider != null)
            Debug.Log("Hit collider 2D"+hit2D.collider.tag);
    }
    public void test(){
        Debug.Log("teste");
    }
    
}
