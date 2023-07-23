// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: DataManager.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.AddressableAssets;

public class DataManager : MonoBehaviour
{
    public void LoadRefDialogueData(Action onLoaded)
    {
        StartCoroutine(DoLoadRefDialogueData("DialogueData", onLoaded));
    }

    public IEnumerator DoLoadRefDialogueData(string path, Action onLoaded)
    {
        bool processing = true;
        string loadedText = "";

        Addressables.LoadAssetAsync<TextAsset>(path).Completed += (op) =>
        {
            loadedText = op.Result.text;

            processing = false;

        };

        while (processing)
        {
            yield return null;
               
        }

        RefData dialogueData = JsonUtility.FromJson<RefData>(loadedText);

        ProcessDialogueData(dialogueData);

        onLoaded?.Invoke();
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

    public void LoadRefCharacterData(Action onLoaded)
    {
        StartCoroutine(DoLoadRefCharacterData("CharacterData", onLoaded));
    }

    public IEnumerator DoLoadRefCharacterData(string path, Action onLoaded)
    {
        bool processing = true;
        string loadedText = "";

        Addressables.LoadAssetAsync<TextAsset>(path).Completed += (op) =>
        {
            loadedText = op.Result.text;

            processing = false;
        };

        while (processing)
        {
            yield return null;
        }

        // Tell the json file that you would like to get data from data string into the dialogue data class
        RefData characterData = JsonUtility.FromJson<RefData>(loadedText);

        // Process Data
        ProcessCharacterData(characterData);

        onLoaded?.Invoke();
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

    public void LoadRefEnemyData(Action onLoaded)
    {
        StartCoroutine(DoLoadRefEnemyData("EnemyData", onLoaded));
    }

    public IEnumerator DoLoadRefEnemyData(string path, Action onLoaded)
    {
        bool processing = true;
        string loadedText = "";

        Addressables.LoadAssetAsync<TextAsset>(path).Completed += (op) =>
        {
            loadedText = op.Result.text;

            processing = false;
        };

        while (processing)
        {
            yield return null;

        }

        // Tell the json file that you would like to get data from data string into the enemy data class
        RefData enemyData = JsonUtility.FromJson<RefData>(loadedText);

        // Process Data
        ProcessEnemyData(enemyData);

        onLoaded?.Invoke();
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

    public void LoadRefEWaveData(Action onLoaded)
    {
        StartCoroutine(DoLoadRefEWaveData("EWaveData", onLoaded));
    }

    public IEnumerator DoLoadRefEWaveData(string path, Action onLoaded)
    {
        bool processing = true;
        string loadedText = "";

        Addressables.LoadAssetAsync<TextAsset>(path).Completed += (op) =>
        {
            loadedText = op.Result.text;

            processing = false;
        };

        while (processing)
        {
            yield return null;

        }


        RefData eWaveData = JsonUtility.FromJson<RefData>(loadedText);

        ProcessEWaveData(eWaveData);

        onLoaded?.Invoke();
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

    public void WriteData<T>(string filepath, T data)
    {
        string dataString = JsonUtility.ToJson(data);
        Debug.Log("rar rar" + dataString);

        File.WriteAllText(filepath, dataString);
    }

    public void SaveData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "SaveData.json");

        DynData dynData = MakeSaveData(Game.GetPlayer());   

        WriteData<DynData>(filePath, dynData);
    }

    //public bool LoadData()
    //{
    //    string filePath = Path.Combine(Application.persistentDataPath, "SaveData.json");

    //    if (File.Exists(filePath))
    //    {
    //        DynData dynData = ReadData<DynData>(filePath);

    //        return true;
    //    }

    //    return false;

    //}

    public DynData MakeSaveData(Player player)
    {
        DynData dynData = new DynData();
        dynData.charChosen  = player.GetCurrentCharacter();

        return dynData;
    }

    //public T ReadData<T> (string filePath)
    //{
    //    string dataString = File.ReadAllText(filePath);

    //    T data = JsonUtility.FromJson<T>(dataString);

    //    return data;
    //}

}

