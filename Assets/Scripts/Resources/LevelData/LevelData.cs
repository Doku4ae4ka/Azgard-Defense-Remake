using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public string levelName;

    public int castleHealth;
    public int startGold;
}
