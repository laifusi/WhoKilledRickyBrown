using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] statementHolders;

    public void OpenStatementHolder(GameObject holder)
    {
        foreach(GameObject stHolder in statementHolders)
        {
            stHolder.SetActive(false);
        }

        holder.SetActive(true);
    }
}
