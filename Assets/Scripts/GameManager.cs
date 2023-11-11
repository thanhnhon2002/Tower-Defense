using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : AdminMonoBehaviour
{
    public static GameManager instance;
    [SerializeField] int level;
    protected DataGameSO dataGameSO;
    protected DataGameEnemy dataGameEnemy;
    protected override void Awake()
    {
        base.Awake();
       
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.dataGameSO = Resources.Load<DataGameSO>("DataGameSO/DataGame");
        DataGameEnemy data = this.dataGameSO.GetDataGameEnemy(level);
        this.dataGameEnemy = new DataGameEnemy(data._level, data._roundList);
    }
    private void Start()
    {
        //UIManager.instance.Announce("Chao mung ban den voi vong "+ level);
        UIManager.instance.Announce("Anh yeu em ");
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        foreach (var round in this.dataGameEnemy._roundList)
        {
            foreach (var dataEnemeInRound in round._listEnemyInRound)
            { 
                for (int i=0;i<dataEnemeInRound._countEnemy;++i)
                {
                    EnemySpawner.instance.Spawn(dataEnemeInRound._enemy.name, Vector3.zero, Quaternion.identity);
                    yield return new WaitForSeconds(0.3f);
                }
            }
            yield return new WaitForSeconds(10);
        }
    }
    public void PauseGame()
    {
        if(Time.timeScale == 0) Time.timeScale = 1;
        else Time.timeScale = 0;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
    
