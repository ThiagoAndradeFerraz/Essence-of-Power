using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMng : MonoBehaviour
{
    // ************************************
    // Used to load the data...
    [SerializeField] private StateManager stateMng;
    [SerializeField] private UIMng uiManager;

    [SerializeField] private TextAsset dialogueJson;

    [System.Serializable]
    public class DialogueLines
    {
        public Dialogue[] dialogue;
    }

    public DialogueLines dialogueLines = new DialogueLines();

    // ************************************
    // Used to iterate the dialogue...
    private bool isTalking = false;
    private int currentPosition = 0;


    // Start is called before the first frame update
    void Start()
    {
        // loading managers...
        //ui manager...
        uiManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<Transform>().GetChild(2).GetComponent<UIMng>();

        // state manager...
        stateMng = GameObject.FindGameObjectWithTag("Managers").GetComponent<Transform>().GetChild(0).GetComponent<StateManager>();
    }

    private void Update()
    {
        if (isTalking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IterateDialogue();
            }
        }
    }

    private void LoadFile(string name, int number)
    {
        string fullPath = "Text Data/PT-BR/DIALOGUES/" + name + "/" + name + "_" + number;
        dialogueJson = Resources.Load<TextAsset>(fullPath);
        dialogueLines = JsonUtility.FromJson<DialogueLines>(dialogueJson.text);
    }

    public void ShowDialogueUI(string name, int number)
    {
        LoadFile(name, number);
        uiManager.TurnOnOffDialogueUI(true);

        // BLOCK GAMEPLAY BY STATE MANAGER
        stateMng.SetState(EStates.DIALOGUE);

        // CALL UI
        uiManager.ShowDialogueUI(dialogueLines.dialogue[0]);

        isTalking = true;
    }

    private void IterateDialogue()
    {
        currentPosition += 1;
        if(currentPosition < dialogueLines.dialogue.Length)
        {
            uiManager.ShowDialogueUI(dialogueLines.dialogue[currentPosition]);
        }
        else
        {
            uiManager.TurnOnOffDialogueUI(false);
            isTalking = false;
            currentPosition = 0;
            stateMng.SetState(EStates.GAMEPLAY);
        }
    }


}
