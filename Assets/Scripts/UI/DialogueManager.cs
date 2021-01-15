using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;

    public Animator animator;
    void Start()
    {
        sentences = new Queue<string>();
    }

    void LateUpdate()
    {
        //check if the player has moved away
        if(PlayerController.instance.focusTarget != null)
        {
            if(PlayerController.instance.focusTarget.GetComponent<NPC>())
            {
                float distance = Vector3.Distance(PlayerManager.instance.player.transform.position, PlayerController.instance.focusTarget.transform.position);

                //cancel dialogue if moved too far
                if(distance > PlayerController.instance.focusTarget.GetComponent<NPC>().radius + PlayerController.instance.focusTarget.GetComponent<NPC>().radiusPadding)
                {
                    animator.SetBool("isOpen", false);
                }
            }
            
        }
        
        
    }
    

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        Debug.Log("Starting conversation with "+dialogue.name);
        nameText.text = dialogue.name;
        sentences.Clear();
        //loop through each sentence in dialogue and add to queue
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

       string sentence = sentences.Dequeue();
       StopAllCoroutines();
       StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation.");
        animator.SetBool("isOpen", false);
        if(QuestManager.instance.questWindow.activeSelf)
        {
            QuestManager.instance.questWindow.SetActive(false);
        }
    }
}
