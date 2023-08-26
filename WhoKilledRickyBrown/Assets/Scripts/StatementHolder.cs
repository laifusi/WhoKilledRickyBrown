using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatementHolder : MonoBehaviour
{
    [SerializeField] private StatementObject linePrefab;
    [SerializeField] private TMP_Text liesText;
    [SerializeField] private GameObject interrogateButton;

    private int countLines;
    private List<StatementSO> statements = new List<StatementSO>();

    public void AddStatement(StatementSO statement)
    {
        if (statements.Contains(statement))
            return;

        StatementObject line = Instantiate(linePrefab, transform);
        line.AssignStatement(statement);
        statements.Add(statement);
        countLines++;
    }

    public void SetLiesNumber(int lies)
    {
        liesText.SetText(lies.ToString());
        CheckInterrogationNeed();
    }

    private void OnEnable()
    {
        CheckInterrogationNeed();
    }

    private void CheckInterrogationNeed()
    {
        if (countLines == 0)
        {
            interrogateButton.SetActive(true);
        }
        else
        {
            interrogateButton.SetActive(false);
        }
    }
}
