using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    Transform Player;
    public Transform InteractionTransform;

    bool isFocused = false;
    bool hasInteracted = false;

    public virtual void Interacte()
    {
        Debug.Log("Interact" + transform.name);
    }

    private void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(Player.transform.position, InteractionTransform.position);
            if(distance <= radius)
            {
                Debug.Log("Inter");
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform PlayerTrans)
    {
        isFocused = true;
        Player = PlayerTrans;
        hasInteracted = false;
    }

    public void OnDeFocus()
    {
        isFocused = false;
        Player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTransform.position, radius);
    }
}
