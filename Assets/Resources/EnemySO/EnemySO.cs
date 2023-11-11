using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Enemy",menuName ="SO/Enemy")]
public class EnemySO : ScriptableObject
{
    public new string name;
    public  float hp;
    public  float atk;
    public  float runSpeed;
    public  float atkSpeed;
    public  float rangeAtk;
    public int gold;
    public  Category category;
   
    
}
