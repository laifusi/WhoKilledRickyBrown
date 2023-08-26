using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Interrogation : MonoBehaviour
{
    [SerializeField] CharacterStatement[] characterStatements;
    [SerializeField] GameObject interrogationPanel;
    [SerializeField] TMP_Text interrogationText;
    [SerializeField] GameObject previousButton;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject closeButton;

    private int currentLine;
    private StatementSO[] statements;
    private StatementHolder holder;
    private int countLies;

    public void Interrogate(CharacterSO character)
    {
        foreach(CharacterStatement chSt in characterStatements)
        {
            if (character == chSt.character)
            {
                statements = chSt.statements;
                holder = chSt.statementsHolder;
                break;
            }
        }
        if (statements == null)
            return;

        interrogationPanel.SetActive(true);
        currentLine = -1;
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (currentLine >= statements.Length)
            return;

        currentLine++;

        StatementSO currentLineStatement = statements[currentLine];
        interrogationText.SetText(currentLineStatement.line);
        interrogationText.color = currentLineStatement.character == null ? Color.white : currentLineStatement.character.color;

        if (currentLineStatement.character != null)
            holder.AddStatement(currentLineStatement);

        UpdateButtons();
    }

    public void ShowPreviousLine()
    {
        if (currentLine - 1 < 0)
        {
            return;
        }

        currentLine--;

        StatementSO currentLineStatement = statements[currentLine];
        interrogationText.SetText(currentLineStatement.line);
        interrogationText.color = currentLineStatement.character == null ? Color.white : currentLineStatement.character.color;

        UpdateButtons();
    }

    private void UpdateButtons()
    {
        previousButton.SetActive(currentLine > 0);
        nextButton.SetActive(currentLine + 1 < statements.Length);
        closeButton.SetActive(currentLine + 1 == statements.Length);
    }

    public void CloseInterrogation()
    {
        holder.SetLiesNumber(CountLies());
        interrogationPanel.SetActive(false);
        statements = null;
    }

    private int CountLies()
    {
        countLies = 0;
        foreach(StatementSO statement in statements)
        {
            if (statement.isFalse)
                countLies++;
        }

        return countLies;
    }
}

[Serializable]
public struct CharacterStatement
{
    public CharacterSO character;
    public StatementSO[] statements;
    public StatementHolder statementsHolder;
}
