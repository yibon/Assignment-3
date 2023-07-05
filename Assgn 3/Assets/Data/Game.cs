using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{

    private static List<Dialogue> dialogueList;

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
