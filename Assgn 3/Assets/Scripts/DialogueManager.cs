using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    //dialogue manager (from csv)
    //> cutscene ref
    //> next cutscene
    //> cutscenesetid
    //> current speaker
    //> left speaker
    //> right speaker
    //> left image
    //> right image
    //> dialogue


    //  currCutscene = cutscenered

    // in update,
    // get mouse input/next line input
    // nextline function

    //  nextline function:
    //  if (currCutScene is not -1)
    //  {	
    //	dialogue text = dialogue


    //    check if the speaker is the left or right speaker
    //		if left,
    //			name text = left speaker
    //            dull the right image(using tint?)
    //		if right,
    //			name text = right speaker
    //			dull the left image

    //	    currCutScene = next cutscene
    //  }

    //  else
    //  {
    //       end dialogue function
    //  }

    // end dialogue function:
    // check the cutsceneset id
    // if the id is 601,
    // game starts

    // if id is 602,
    // endgame sequence commences.
}
