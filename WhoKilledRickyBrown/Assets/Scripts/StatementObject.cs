using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatementObject : MonoBehaviour
{
    [SerializeField] private StatementSO statementSO;
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        //AssignStatement(statementSO);
    }

    public void AssignStatement(StatementSO statement)
    {
        statementSO = statement;

        text.color = statementSO.character.color;
        text.SetText(statementSO.line);
    }

    public bool CheckStatement()
    {
        return statementSO.isFalse;
    }
}
