using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Defender", menuName = "SO/Defender")]
public class DefenderSO : ScriptableObject
{
    public new string name;
    public int atk;
    public int hp;
    public float atkSpeed;
    public float runSpeed;
    public float rangeAtk;
    public int currentLevel;
    public int maxLevel;
    public Category category;
}
