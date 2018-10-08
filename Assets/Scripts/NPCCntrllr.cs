using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCCntrllr : Interactable {

    bool visited;
    Animator anim;
    DialogueRunner diagRunner;
    public GameObject interactionBubble;

    private void Awake()
    {
        anim = interactionBubble.GetComponent<Animator>();
        diagRunner = GetComponent<DialogueRunner>();
        visited = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("inRange", true);

            if (visited == false)
            {
                anim.SetInteger("iconToShow", 0);
            }
            else
            {
                anim.SetInteger("iconToShow", 2);
            }
        }
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                diagRunner.StartDialogue();
                anim.SetInteger("iconToShow", 1);
                visited = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        anim.SetBool("inRange", false);
    }
}
