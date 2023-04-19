using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Tree", menuName = "ScriptableObjects/Tree")]

[System.Serializable]
public class SO_Trees : ScriptableObject
{
    public string treeName;
    public int baseCost;
    public float baseTime;
    public Sprite treeSprite;
}
