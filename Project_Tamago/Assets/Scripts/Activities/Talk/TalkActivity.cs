using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

public class TalkActivity : GenericActivity
{
    // if the button is clicked on, it should prompt the tama to talk. 
    // this should create a query that uses all the currently loaded rules to determine the dialogue lines.

    //

    // the response, along with prompting that particular dialogue, should then nullify the context data relevant to that dialogue since it's been said, but leave other data alone so
    // that the next query can use it to poll the appropriate dialogue. for example, if you bathed tama, and fed it a food it dislikes, it should comment on the food first, then 
    // remove the last eaten food var, and the next query can otherwise use the same values


    // in certain cases, we'd want the game to force a talk, eg if something calls for checking a query that would prompt the force talk if it passes.

    [SerializeField] TalkDecisionHandler talkDecisionHandler;
    public static Criteria activeDialogueCriteria;
    Dialogue currentDialogue;
    Dialogue failsafeDialogue;
    int currentLine;

    [SerializeField] TextMeshProUGUI dialogueUIText;
    [SerializeField] SpriteRenderer largeCritterSprite;

    void Start()
    {
        talkDecisionHandler = new TalkDecisionHandler();
        activeDialogueCriteria = new Criteria();

        activeDialogueCriteria.gameStateBools["hungerIsAt20OrLower"] = true;
        activeDialogueCriteria.gameStateBools["hungerIsBetween21And50"] = false;
        activeDialogueCriteria.gameStateBools["hungerIsAt51OrHigher"] = false;

        failsafeDialogue = new Dialogue(new string[] { "i don't really have anything to say rn" }, new TalkExpression[] {TalkExpression.expressionless});
    }

    internal override void ChangeScreen()
    {
        File.WriteAllText(Application.dataPath + "/CurrentCriteria.json", activeDialogueCriteria.CriteriaToString());

        TextAsset currentCriteria = JsonUtility.FromJson<TextAsset>(File.ReadAllText(Application.dataPath + "/CurrentCriteria.json"));
        // should probably calculate, or retreive current query somewhere here?
        currentDialogue = talkDecisionHandler.DetermineDialogue(currentCriteria);


        if (currentDialogue == null)
            currentDialogue = failsafeDialogue;

        dialogueUIText.text = currentDialogue.linesToSay[0];
        currentLine = 0;


        largeCritterSprite.sprite = GameStateManager.Instance.CritterRef.CurrentSpecies.characterTalkSprites[(int)currentDialogue.expressions[currentLine]];
        GameStateManager.Instance.CritterRef.ToggleVisibility(false);

        mainScreen.SetActive(true);
        Debug.Log(JsonConvert.SerializeObject(activeDialogueCriteria));
         
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            currentLine += 1;

            if (currentLine >= currentDialogue.linesToSay.Length)
            {
                currentDialogue.OnSaid();
                EndActivity();
            }
            else
            {
                dialogueUIText.text = currentDialogue.linesToSay[currentLine];
                largeCritterSprite.sprite = GameStateManager.Instance.CritterRef.CurrentSpecies.characterTalkSprites[(int)currentDialogue.expressions[currentLine]]; // absolute unit of a line. please make it shorter
            }
        }
    }


    internal override void ActivityFinishCleanup()
    {
        GameStateManager.Instance.CritterRef.ToggleVisibility(true);
        mainScreen.SetActive(false);
    }
}