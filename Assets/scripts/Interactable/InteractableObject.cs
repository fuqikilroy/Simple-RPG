using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    private bool haveInteracted = false;

    public void OnClick(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 2;
        playerAgent.SetDestination(transform.position);
        haveInteracted = false;
        //Interact();
    }

    private void Update()
    {
        if (playerAgent != null && haveInteracted == false && playerAgent.pathPending == false)
        {
            if (playerAgent.remainingDistance <= 2)
            {
                Interact();
                haveInteracted = true;
            }
        }
    }

    protected virtual void Interact()
    {
        print("Interacting with Interactable Object.");
    }
}
