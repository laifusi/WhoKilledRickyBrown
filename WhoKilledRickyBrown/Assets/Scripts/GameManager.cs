using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] statementHolders;
    [SerializeField] Transform liesPanel;
    [SerializeField] CharacterSO realKiller;
    [SerializeField] int totalLies = 19;
    [SerializeField] TMP_Text endingText;
    [SerializeField] TMP_Text liesText;
    [SerializeField] GameObject conclusionPanel;

    private CharacterSO selectedKiller;

    public void OpenStatementHolder(GameObject holder)
    {
        foreach(GameObject stHolder in statementHolders)
        {
            stHolder.SetActive(false);
        }

        holder.SetActive(true);
    }

    public void SelectKiller(CharacterSO character)
    {
        selectedKiller = character;
        SolveCrime();
    }

    public void SolveCrime()
    {
        StatementObject statement;
        int liesRight = 0;

        foreach (Transform child in liesPanel)
        {
            statement = child.GetComponent<StatementObject>();
            if(statement != null)
            {
                if(statement.StatementIsFalse())
                {
                    liesRight++;
                }
            }
        }

        liesText.SetText("You uncovered " + liesRight + "/" + totalLies + " lies.");

        if(selectedKiller == realKiller)
        {
            endingText.SetText("Congratulations! You caught the killer.");
        }
        else
        {
            endingText.SetText("Oh no... The real killer escaped and an innocent person went to prison.");
        }

        conclusionPanel.SetActive(true);
    }
}
