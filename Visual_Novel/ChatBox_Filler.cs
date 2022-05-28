using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChatBox_Filler : MonoBehaviour
{
    public static ChatBox_Filler Instance;
    public TextMeshProUGUI main_textMeshPro;
    public GameObject leftCharacterNameBox;
    public GameObject rightCharacterNameBox;
    private TextMeshProUGUI leftCharacterName;
    private TextMeshProUGUI rightCharacterName;
    [HideInInspector]
    public GameObject mainWindow;
    [HideInInspector]
    public Image bgImage, chrImage;

    bool finishedProcess = true;
    [Space]
    [HideInInspector]
    public GameObject buttonAnswerOne, buttonAnswerTwo, buttonAnswerThree;
    [HideInInspector]
    public TextMeshProUGUI buttonTextOne, buttonTextTwo, buttonTextThree;

    [HideInInspector]
    public Animator AchPopUp;
    [HideInInspector]
    public Image AchImage;
    [HideInInspector]
    public Text AchText;

    [HideInInspector]
    public GameObject inputNameBox;
    [HideInInspector]
    public GameObject submitChoiceButton;
    [HideInInspector]
    public Text nameInputField;
    [HideInInspector]
    public Button continueButton;
    [Space]
    public string characterNameToDisplay;
    public string spiderName;
    public string buffName;
    public string deerName;

    [Space]
    public List<CharacterHolder> characters;
    int nextIdSave;
    int currIdSave;
    int ending;
    

    [HideInInspector]
    public List<int> questionId;
    public List<bool> causesList;
    public List<int> reputation;
    public List<int> finishResults;
    public List<string> achievementNames;

    [Space]
    public List<GameObject> musicPlayers;
    public List<Sprite> bcgImageSprite;
    public List<Sprite> textboxSpire;
    [Space]
    public List<Sprite> spiderImageSprite;
    public List<Sprite> buffImageSprite;
    public List<Sprite> deerImageSprite;
    [Space]
    public bool newGame;
    public int savedStage;

    private void Awake()
    {
        Instance = this;
        leftCharacterName = leftCharacterNameBox.GetComponentInChildren<TextMeshProUGUI>();
        rightCharacterName = rightCharacterNameBox.GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void ReturnToScreen()
    {
        GameObject objs = GameObject.FindGameObjectWithTag("GameController");
        Destroy(objs);
        SceneManager.LoadScene(0);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(currIdSave, newGame, reputation[0], reputation[1], reputation[2], causesList[1], causesList[3], causesList[4]);
    }

    private void Start()
    {
        chrImage.enabled = false;
        mainWindow.SetActive(false);
        leftCharacterNameBox.SetActive(false);
        rightCharacterNameBox.SetActive(false);

        /*if (!newGame)
        {
            characters[0].characterDialogue[0].PassDataToFiller();
        } else
        {
            PassData(savedStage);
        }*/
    }

    public void StartGame()
    {
        mainWindow.SetActive(true);
        GameObject objs = GameObject.FindGameObjectWithTag("GameController");
        if (objs != null)
        {
            Debug.LogError("Aleph");
            newGame = SavedData.Instance.newGame;
            causesList = SavedData.Instance.causesList;
            reputation = SavedData.Instance.reputation;
            savedStage = SavedData.Instance.savedStage;
            PassData(savedStage);
        }
        else
        {
            PassData(savedStage);
        }
    }

    //Inputting Name Zone
    //InputNameStart gets called to activate name entering window, as well as disables button to continue.
    public void InputNameStart(int nextID)
    {
        nextIdSave = nextID;
        continueButton.interactable = false;
        inputNameBox.SetActive(true);
        submitChoiceButton.SetActive(true);
    }
    //InputNameFinish gets called to deactivate name entering window, as well as enable button to continue and continues.
    public void InputNameFinish()
    {
        inputNameBox.SetActive(false);
        submitChoiceButton.SetActive(false);
        characterNameToDisplay = nameInputField.text;
        continueButton.interactable = true;
        DefaultKeyPress();
    }

    //Call this to pass dialogue to the Chatbox filler. 
    public void PassedDialogue(string name, int image, string text, int effects, int pos, float speed, int nextID)
    {
        main_textMeshPro.margin = new Vector4(10, 60, 10, 0);
        currIdSave = nextIdSave;
        nextIdSave = nextID;
        if (text.Contains("@"))
        {
            if (text.Contains("@MyName"))
            {
                text = text.Replace("@MyName", characterNameToDisplay);
            }
            if (text.Contains("@SpiderName"))
            {
                text = text.Replace("@SpiderName", spiderName);
            }
            if (text.Contains("@DeerName"))
            {
                text = text.Replace("@DeerName", deerName);
            }
            if (text.Contains("@BuffName"))
            {
                text = text.Replace("@BuffName", buffName);
            }
        }
        switch (name)
        {
            case "@MyName":
                name = characterNameToDisplay;
                break;
            case "@SpiderName":
                name = spiderName;
                break;
            case "@BuffName":
                name = buffName;
                break;
            case "@DeerName":
                name = deerName;
                break;
            case null:
                break;
        }

        ChangeImage(image);

        if (pos == 0)
        {
            leftCharacterName.text = name;
            leftCharacterNameBox.SetActive(true);
            rightCharacterNameBox.SetActive(false);
        }
        else
        {
            rightCharacterName.text = name;
            rightCharacterNameBox.SetActive(true);
            leftCharacterNameBox.SetActive(false);
        }
        StartCoroutine(Continue(text, speed));
    }

    public void PassData(int numb)
    {
        int tempIdLink = numb / 100;
        int tempIdText;
        if (tempIdLink > 0)
        {
            //Adjustement due to the bug in calculations- From 100 numbers are correct, but before 100 there is a difference in 1. Instead of changing 100 entries I decided to do it this way. 
            tempIdText = (numb - (tempIdLink * 100));
        }
        else
        {
            tempIdText = (numb - (tempIdLink * 100)) - 1;
        }

        mainWindow.GetComponent<Image>().sprite = textboxSpire[tempIdLink];

        //SavePlayer();
        characters[tempIdLink].characterDialogue[tempIdText].PassDataToFiller();
    }

    public void PassMusic(int id)
    {
        if (musicPlayers[id].activeSelf)
        {
            musicPlayers[id].SetActive(false);
        } else
        {
            musicPlayers[id].SetActive(true);
        }
    }

    public void PassedDescription(string text, float speed, int nextID, int image, int bcgimage)
    {
        main_textMeshPro.margin = new Vector4(10, 10, 10, 0);
        mainWindow.GetComponent<Image>().sprite = textboxSpire[0];
        if (text.Contains("@MyName"))
        {
            text = text.Replace("@MyName", characterNameToDisplay);
        }
        if (text.Contains("@SpiderName"))
        {
            text = text.Replace("@SpiderName", spiderName);
        }
        if (text.Contains("@DeerName"))
        {
            text = text.Replace("@DeerName", deerName);
        }
        if (text.Contains("@BuffName"))
        {
            text = text.Replace("@BuffName", buffName);
        }

        if (bcgimage != 0)
        {
            bgImage.sprite = bcgImageSprite[bcgimage];
        }

        ChangeImage(image);

        currIdSave = nextIdSave;
        nextIdSave = nextID;
        leftCharacterNameBox.SetActive(false);
        rightCharacterNameBox.SetActive(false);
        StartCoroutine(Continue(text, speed));
    }

    public void Questionaire(string textOne, string textTwo, string textThree, int idOne, int idTwo, int idThree)
    {
        currIdSave = nextIdSave;
        continueButton.interactable = false;
        questionId[0] = idOne;
        questionId[1] = idTwo;
        questionId[2] = idThree;

        if(idThree > 0)
        {
            //Debug.Log(textOne);
            buttonTextOne.text = textOne;
            buttonTextTwo.text = textTwo;
            buttonTextThree.text = textThree;
            buttonAnswerOne.SetActive(true);
            buttonAnswerTwo.SetActive(true);
            buttonAnswerThree.SetActive(true);
        } else
        {
            //Debug.Log(textOne);
            buttonTextOne.text = textOne;
            buttonTextTwo.text = textTwo;
            buttonAnswerOne.SetActive(true);
            buttonAnswerTwo.SetActive(true);
        }
    }

    public void Split(int clause, int idOne, int idTwo)
    {
        currIdSave = nextIdSave;
        Debug.Log("Split Before");
        if(causesList[clause] == true)
        {
            PassData(idOne);
        } else
        {
            PassData(idTwo);
        }
    }

    public void DefaultKeyPress()
    {
        if (finishedProcess)
        {
            PassData(nextIdSave);
        }
        else
        {
            //musicPlayers[0].SetActive(false);
            finishedProcess = true;
        }
        
    }

    public void PassRelationshipAndConsequences(int consequenceID, int bonusRep, int bonusRepID, bool stopImage)
    {
        if (consequenceID > 0)
        {
            causesList[consequenceID] = true;
        }
        if (bonusRep != 0)
        {
            reputation[bonusRepID] += bonusRep;
        }
        if (stopImage)
        {
            chrImage.enabled = false;
        }
    }


    public void AnswerKeyPress(int number)
    {
        continueButton.interactable = true;
        PassData(questionId[number]);
        questionId[0] = 0;
        questionId[1] = 0;
        questionId[2] = 0;
        buttonAnswerOne.SetActive(false);
        buttonAnswerTwo.SetActive(false);
        buttonAnswerThree.SetActive(false);
    }

    public void Finishing()
    {
        //Finale- Found first Love
        if(reputation[0] >= 5 || reputation[1] >= 5 || reputation[2] >= 5)
        {
            ending = 0;
            nextIdSave = finishResults[0];
        } 
        //Finale- Found a friend
        else if (reputation[0] >= 3 || reputation[1] >= 3 || reputation[2] >= 3)
        {
            ending = 1;
            nextIdSave = finishResults[1];
        } 
        //Finale- Met some people
        else if (reputation[0] >= 1 && reputation[1] >= 1 && reputation[2] >= 1)
        {
            ending = 2;
            nextIdSave = finishResults[2];
        }
        //Finale- Somebody
        else if (reputation[0] >= 1 || reputation[1] >= 1 || reputation[2] >= 1)
        {
            ending = 3;
            nextIdSave = finishResults[3];
        }
        //Finale- Alone
        else
        {
            ending = 4;
            nextIdSave = finishResults[4];
        }
        PassData(nextIdSave);

    }
    
    public void StopTrigger()
    {
        StartCoroutine(Stop());
    }
    public IEnumerator Stop()
    {
        mainWindow.SetActive(false);
        continueButton.interactable = false;
        //display achievement
        if (newGame)
        {
            int resultToSend = reputation[2] + 4 + ((reputation[1] + 4) * 10) + ((reputation[0] + 4) * 100);
            gameObject.GetComponent<Leaderboard_Push>().result = resultToSend;
            gameObject.GetComponent<Leaderboard_Push>().playerName = characterNameToDisplay;
            gameObject.GetComponent<Leaderboard_Push>().SubmitScore();
        }
        yield return new WaitForSecondsRealtime(3f);
        AchText.text += achievementNames[ending];
        AchPopUp.SetTrigger("AchievementPopUp");
        yield return new WaitForSecondsRealtime(3f);
        ReturnToScreen();

    }

    public void ChangeImage(int newI)
    {
        int chr = (newI / 100);
        newI = newI - (chr * 100);

        if (newI != 0)
        {
            chrImage.enabled = true;
            switch (chr)
            {
                case 0:
                    chrImage.sprite = spiderImageSprite[newI];
                    break;
                case 1:
                    chrImage.sprite = deerImageSprite[newI];
                    break;
                case 2:
                    chrImage.sprite = buffImageSprite[newI];
                    break;

            }
            //chrImage.sprite = characterTags[chr][newI];
        }
    }

    IEnumerator Continue(string dialogText, float speedOfLetters)
    {
        if(speedOfLetters != 0.05f)
        {
            speedOfLetters = 0.01f;
        }
        finishedProcess = false;
        main_textMeshPro.text = dialogText;
        int totalVisibleCharacters = dialogText.Length;
        int counter = 0;
        //musicPlayers[0].SetActive(true);
        while (!finishedProcess)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            main_textMeshPro.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                finishedProcess = true;
            }

            counter += 1;

            yield return new WaitForSeconds(speedOfLetters);
        }
        //musicPlayers[0].SetActive(false);
        main_textMeshPro.maxVisibleCharacters = totalVisibleCharacters;
        finishedProcess = true;
    }
}
