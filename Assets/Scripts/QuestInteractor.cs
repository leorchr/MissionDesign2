using UnityEngine;
using System.Collections.Generic;

public class QuestInteractor : Interactive
{
    public QuestGiver QGInfo;

    public override void OnInteraction()
    {
        QuestManager.Instance.checkInteract(QGInfo);

        bool questGiven = QGInfo.GiveNextQuest();
        if (questGiven)
        {
            DialogueManager.instance.PlayDialogue(QGInfo.currentQuest.GetCurrentStep().BeginDialogue);
        }
        else
        {
            if (QGInfo.currentQuest != null)
            {
                DialogueSC currentQDialogue = QGInfo.currentQuest.GetCurrentStep().BeginDialogue;
                if (currentQDialogue != null) { DialogueManager.instance.PlayDialogue(currentQDialogue); }
                else { DialogueManager.instance.PlayDialogue(QGInfo.defaultDialogue); }
                
            }
            else
            {
                DialogueManager.instance.PlayDialogue(QGInfo.defaultDialogue);
            }
        }
        
       
        
    }

    
}