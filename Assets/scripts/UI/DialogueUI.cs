using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{

    public static DialogueUI Instance { get; private set; }

    private Text nameText;
    private Text contentText;
    private Button continueButton;

    private List<string> contentList;
    private int contentIndex = 0;

    private GameObject uiGameObject;

    private Action OnDialogueEnd;

    private void Awake()
    {
        if(Instance!=null && Instance!=this)
        {
            Destroy(this.gameObject);return;
        }

        Instance = this;
    }

    private void Start()
    {
        nameText = transform.Find("UI/NameTextBg/NameText").GetComponent<Text>();
        contentText = transform.Find("UI/ContentText").GetComponent<Text>();
        continueButton = transform.Find("UI/ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
        uiGameObject = transform.Find("UI").gameObject;
        Hide();
    }

    public void Show()
    {
        uiGameObject.SetActive(true);
    }

    public void Show(string name,string[] content,Action OnDiagoueEnd=null)
    {
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentIndex = 0;
        contentText.text = contentList[0];
        uiGameObject.SetActive(true);
        this.OnDialogueEnd = OnDiagoueEnd;
    }
     
    public void Hide()
    {
        uiGameObject.SetActive(false);
    }


    private void OnContinueButtonClick()
    {
        contentIndex++;
        if (contentIndex >= contentList.Count)
        {
            OnDialogueEnd?.Invoke();
            Hide();return;
        }

        contentText.text = contentList[contentIndex];
        
    }
    
}
