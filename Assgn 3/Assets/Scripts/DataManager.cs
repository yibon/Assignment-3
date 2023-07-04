using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadRefData();
    }

    public void LoadRefData()
    {
        string filePath = Path.Combine(Application.dataPath, "Data/dialogue_data.txt");

        string dataString = File.ReadAllText(filePath);
        //Debug.Log(dataString);

        // Tell the json file that you would like to get data from data string into the dialogue data class
        DialogueData dialogueData = JsonUtility.FromJson<DialogueData>(dataString);

        // Process Data
        ProcessDialogueData(dialogueData);
    }

    private void ProcessDialogueData(DialogueData dialogueData)
    {
        // Dialogue Table
        List<Dialogue> dialoguelist = new List<Dialogue>();

        foreach (RefDialogue refDialogue in dialogueData.RefDialogue)
        {
            Dialogue.CurrentSpeaker currSpeaker = (Dialogue.CurrentSpeaker)System.Enum.Parse(typeof(Dialogue.CurrentSpeaker), refDialogue.currentSpeaker);

            Dialogue dialogue = new Dialogue(refDialogue.cutsceneRefId, refDialogue.nextCutsceneRefId, refDialogue.cutsceneSetId,
                                             currSpeaker, refDialogue.leftImage, refDialogue.rightImage,
                                             refDialogue.dialogue, refDialogue.speakerName);

            dialoguelist.Add(dialogue);
        }

        Game.SetDialogueList(dialoguelist);

        // Debug.Log(Game.GetDialogueList().Count);
    }
}

