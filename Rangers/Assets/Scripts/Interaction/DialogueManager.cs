using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private MouseInteraction mouseInteraction;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image CharacterArt;
    public Animator animator;
    private Queue<string> sentences;
    void Start() {
        sentences = new Queue<string>();    
    }
    public void StartDialogue(Dialogue dialogue, GameObject NPC){
        Debug.Log("teste2");
        mouseInteraction.EnableDialogue();
        animator.SetBool("IsDialogueOpen", true);

        nameText.text = NPC.GetComponent<InteractMenu>().GetText();

        CharacterArt.sprite =  NPC.GetComponent<InteractMenu>().GetCharArt();

        sentences.Clear();

        foreach(string sentenc in dialogue.frases){
            sentences.Enqueue(sentenc);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence(){
        if(sentences.Count==0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence){
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }
    void EndDialogue(){
        animator.SetBool("IsDialogueOpen", false);
        mouseInteraction.DisableDialogue();
    }
}
