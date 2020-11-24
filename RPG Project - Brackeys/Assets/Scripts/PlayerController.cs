using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;

    public LayerMask mask;

    Camera cam;

    PlayerMotor motor;
    
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit , 100 , mask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }

        if (Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    setFocus(interactable);
                }
            }
        }
    }

    void setFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDeFocus();
            focus = newFocus;
            newFocus.OnFocused(transform);
        }
        
        motor.FollowTarget(newFocus);
    }

    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDeFocus();
;       focus = null;
        motor.StopFollowTarget();
    }
}
