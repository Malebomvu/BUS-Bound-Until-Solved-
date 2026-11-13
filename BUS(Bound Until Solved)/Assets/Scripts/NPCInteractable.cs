using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField]
    private string npcName = "Yanga";
    [SerializeField, TextArea(2, 4)]
    private string[] dialogueLines = {"Hey, do you notice anything weird?," +
            "What is that sound? Im starting to be scared",
    "Where is my phone can you please find it for me.",
    "It is very important."};

    private int dialogueIndex;
    private bool isTalking;
    public bool IsTalking => isTalking;
    public string CurrentDialogue
    { get
        { if (dialogueLines == null || dialogueLines.Length == 0) return "...";
            int index = Mathf.Clamp(dialogueIndex, 0, dialogueLines.Length - 1);
            return dialogueLines[index];
        } 
    }

    public string NpcName => npcName;

    public void Interact()
    { if (dialogueLines == null || dialogueLines.Length == 0)
        { Debug.Log($"{npcName}: No dialogue has been set.", this); return;};

    if (!isTalking)
        { isTalking = true;
            dialogueIndex = 0;
            return;
        }

        dialogueIndex++;
        if (dialogueIndex >= dialogueLines.Length)
        { isTalking = false;
            dialogueIndex = 0;
        }
    }

    public void EndConversation()
    { isTalking = false;
        dialogueIndex = 0;
    }
}
