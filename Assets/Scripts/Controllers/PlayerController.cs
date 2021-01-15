using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    #region Singleton

    public static PlayerController instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public Interactable focus;
    public LayerMask moveMask;
    public GameObject focusTarget;
    Camera cam;

    PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //add code for mouseover outline here

        //If left click, do something
        if (Input.GetMouseButtonDown(0))
        {
            //Removed left click walking for a rework
            //LeftClickEvent();
        }

        //If right click, do something
        if (Input.GetMouseButtonDown(1))
        {
            RightClickEvent();
        }
    }

    

    public virtual void RightClickEvent()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Cast a ray to whatever you click, then execute something
            //Physics.Raycast(Ray ray, out hit, int range, LayerMask mask)
        if(Physics.Raycast(ray, out hit, 100))
        {
            //Check if interactable
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            //If yes, set focus
            if (interactable != null)
            {
                SetFocus(interactable);
                focusTarget = focus.gameObject;
                if(focusTarget.GetComponent<ItemPickup>())
                {
                    DrawOutline();
                }
                
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDeFocused();
            }            
            focus = newFocus;
            //move towards focus
            motor.FollowTarget(newFocus);
        }
            
        newFocus.OnFocused(transform);
            
    }

    void RemoveFocus()
    {
        if(focus != null)
        {
            focus.OnDeFocused();
        }
        focus = null;
        //stop follow target
        motor.StopFollowTarget();
        if(focusTarget != null && focusTarget.GetComponent<ItemPickup>())
        {
            RemoveOutline();
        }
    }

    void DrawOutline()
    {
        focusTarget.GetComponent<Renderer>().material.SetFloat("_Outline", 0.15f);
    }

    void RemoveOutline()
    {
        focusTarget.GetComponent<Renderer>().material.SetFloat("_Outline", 0f);
    }
}
