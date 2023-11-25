using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TowerDefense",menuName ="SO/TowerDefense")]
public class TowerDefenseSO : ScriptableObject
{
    public new string name;
    public int atk;
    public float atkSpeed;
    public  float rangeAtk;
    public  int price;
    public  int maxLevel;
    public  Category category;

}
