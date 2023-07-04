using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    private static List<Dialogue> DialogueList;

    public static List<Dialogue> GetDialogueList()
    {
        return DialogueList;
    }

    public static void SetDialogueList(List<Dialogue> _list)
    {
        DialogueList = _list;
    }

    public static Dialogue GetDialogueByRefId(string _refId)
    {
        return DialogueList.Find(x => x.cutsceneRefId == _refId);
    }

}
