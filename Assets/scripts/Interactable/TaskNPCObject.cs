using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskNPCObject : InteractableObject
{
    public string npcName;
    public GameTaskSO gameTaskSO;

    public string[] contentInTaskExecuting;
    public string[] contentInTaskCompleted;
    public string[] contentInTaskEnd;

    private void Start()
    {
        gameTaskSO.state = GameTaskState.Waiting;
    }

    protected override void Interact()
    {
        switch (gameTaskSO.state)
        {
            case GameTaskState.Waiting:
                DialogueUI.Instance.Show(npcName, gameTaskSO.diague, OnDialogueEnd);
                break;
            case GameTaskState.Executing:
                DialogueUI.Instance.Show(npcName, contentInTaskExecuting);
                break;
            case GameTaskState.Completed:
                DialogueUI.Instance.Show(npcName, contentInTaskCompleted, OnDialogueEnd);
                break;
            case GameTaskState.End:
                DialogueUI.Instance.Show(npcName, contentInTaskEnd);
                break;
            default:
                break;
        }
    }

    public void OnDialogueEnd()
    {
        switch (gameTaskSO.state)
        {
            case GameTaskState.Waiting:
                gameTaskSO.Start();
                InventoryManager.Instance.AddItem(gameTaskSO.startReward);
                MessageUI.Instance.Show("你接受了一个任务！");
                break;
            case GameTaskState.Executing:
                break;
            case GameTaskState.Completed:
                gameTaskSO.End();
                InventoryManager.Instance.AddItem(gameTaskSO.endReward);
                MessageUI.Instance.Show("任务已提交！");
                break;
            case GameTaskState.End:
                break;
            default:
                break;
        }


    }
}
