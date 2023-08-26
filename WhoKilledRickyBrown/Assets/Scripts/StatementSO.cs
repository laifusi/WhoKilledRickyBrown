using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Statement")]
public class StatementSO : ScriptableObject
{
    public string line;
    public bool isFalse;
    public CharacterSO character;
}
