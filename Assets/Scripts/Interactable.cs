using UnityEngine;


public class Interactable : MonoBehaviour
{
    //how close do you have to be to interact?
    public float radius = 3f;
    public float radiusPadding;
    public Transform interactPosition;
    bool hasInteracted = false;
    bool isFocus = false;
    Transform player;

    public virtual void Interact()
    {
        //Kinda like an interface. This says "Hey, 
        //I'll have an interact method that's overwritten for use cases
        //Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactPosition.position);
            if(distance <= radius)
            {
                //Debug.Log("Interacting...");
                hasInteracted = true;
                Interact();
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isFocus = true;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactPosition == null)
        {
            interactPosition = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactPosition.position, radius);
    }
}
