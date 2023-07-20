// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: DataManager.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.TextCore.Text;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadDialogueRefData();
        LoadRefCharacterData();
        LoadRefEnemyData();
        LoadRefEWaveData();
    }

    public void LoadDialogueRefData()
    {
        // 
        string filePath = "Assets/Data/dialogue_data.txt";
        string dataString = File.ReadAllText(filePath);

        // Tell the json file that you would like to get data from data string into the dialogue data class
        RefData dialogueData = JsonUtility.FromJson<RefData>(dataString);

        // Process Data
        ProcessDialogueData(dialogueData);
    }

    private void ProcessDialogueData(RefData dialogueData)
    {
        // Dialogue Table
        List<Dialogue> dialoguelist = new List<Dialogue>();

        foreach (RefDialogue refDialogue in dialogueData.RefDialogue)
        {
            Dialogue.CurrentSpeaker currSpeaker = (Dialogue.CurrentSpeaker)System.Enum.Parse(typeof(Dialogue.CurrentSpeaker), refDialogue.currentSpeaker);

            Dialogue dialogue = new Dialogue(refDialogue.cutsceneRefId, refDialogue.nextCutsceneRefId, refDialogue.cutsceneSetId,
                                             currSpeaker, refDialogue.leftImage, refDialogue.rightImage,
                                             refDialogue.dialogue, refDialogue.speakerName, refDialogue.choices);

            dialoguelist.Add(dialogue);
        }

        Game.SetDialogueList(dialoguelist);

        // Debug.Log(Game.GetDialogueList().Count);
    }

    public void LoadRefCharacterData()
    {
        string filePath = "Assets/Data/character_data.txt";
        string dataString = File.ReadAllText(filePath);

        // Tell the json file that you would like to get data from data string into the dialogue data class
        RefData characterData = JsonUtility.FromJson<RefData>(dataString);

        // Process Data
        ProcessCharacterData(characterData);
    }

    private void ProcessCharacterData(RefData characterData)
    {
        // Character Table
        List<Character> characterlist = new List<Character>();

        foreach (RefCharacter refCharacter in characterData.RefCharacter)
        {
            Character character = new Character(refCharacter.characterId, refCharacter.characterName, refCharacter.characterHP,
                                                refCharacter.characterAttk, refCharacter.characterMoveSpeed);

            characterlist.Add(character);
        }

        Game.SetCharacterList(characterlist);
        //Debug.Log(Game.GetCharacterList().Count);
    }

    public void LoadRefEnemyData()
    {
        string filePath = "Assets/Data/enemy_data.txt";
        string dataString = File.ReadAllText(filePath);

        // Tell the json file that you would like to get data from data string into the enemy data class
        RefData enemyData = JsonUtility.FromJson<RefData>(dataString);

        // Process Data
        ProcessEnemyData(enemyData);
    }

    private void ProcessEnemyData(RefData enemyData)
    {
        List<Enemy> enemyList = new List<Enemy>();

        foreach (RefEnemy refEnemy in enemyData.RefEnemy)
        {
            //Debug.Log(enemyData.RefEnemy[1]);
            Enemy enemy = new Enemy(refEnemy.enemyId, refEnemy.enemyName, refEnemy.enemyHeath,
                                    refEnemy.enemyAttack, refEnemy.enemySpeed);

            enemyList.Add(enemy);
        }

        Game.SetEnemyList(enemyList);
        //Debug.Log("FEWFEWFEW " + Game.GetEnemyList().Count);
    }

    public void LoadRefEWaveData()
    {
        string filePath = "Assets/Data/ewave_data.txt";
        string dataString = File.ReadAllText(filePath);

        RefData eWaveData = JsonUtility.FromJson<RefData>(dataString);

        ProcessEWaveData(eWaveData);
    }

    private void ProcessEWaveData(RefData eWaveData)
    {
        List <EnemyWave> enemyWaveList = new List<EnemyWave>();
        foreach (RefEWave refewave in eWaveData.RefEWave)
        {
            EnemyWave enemyWave = new EnemyWave(refewave.waveId, refewave.enemyId, refewave.spawnDelay,
                                                refewave.enemyCount, refewave.spawnPoint, refewave.nextWaveId);

            enemyWaveList.Add(enemyWave);
        }

        Game.SetEnemyWaveList(enemyWaveList);
    }
}

