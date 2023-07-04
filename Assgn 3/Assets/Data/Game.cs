using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    private static CutScenes cutscene;

    private static List<Dialogue> dialogueList;

    public static CutScenes GetDialogue()
    {
        return cutscene;
    }

    public static void SetDialogue(CutScenes _cutscene)
    {
        cutscene = _cutscene;   
    }


    public static List<Dialogue> GetDialogueList()
    {
        return dialogueList;
    }

    public static void SetDialogueList(List<Dialogue> _list)
    {
        dialogueList = _list;
    }

    public static Dialogue GetDialogueByRefId(string _refId)
    {
        return dialogueList.Find(x => x.cutsceneRefId == _refId);
    }

}
