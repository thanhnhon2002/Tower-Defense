using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : AdminMonoBehaviour
{
    [SerializeField] float gameSpeed;
    public static GameManager instance;
    [SerializeField] int level;
    public int _level => level;
    [SerializeField] protected DataGameSO dataGameSO;
    protected DataGameEnemy dataGameEnemy;
    [SerializeField] DataPlayerSO dataPlayerSO;
    bool isEndGame=false;
    public void SetGameSpeed(float speed)
    {
        this.gameSpeed = speed;
    }
    public void SetLevel(int level)
    {
        this.level = level;
    }
    protected override void Awake()
    {
        base.Awake();
        this.ContinueGame();
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.dataPlayerSO = Resources.Load<DataPlayerSO>("DataPlayerSO/DataPlayer");
        if (this.level == 0) return;
        this.dataGameSO = Resources.Load<DataGameSO>("DataGameSO/DataGame");      
        DataGameEnemy data = this.dataGameSO.GetDataGameEnemy(level);
        this.dataGameEnemy = new DataGameEnemy(data._level, data._roundList);
    }
    private void Start()
    {
      
        Screen.SetResolution(960, 540, FullScreenMode.Windowed);
        if (this.level == 0)
        {
            this.UnLockLevel(1);
            return;
        }
        UIManager.instance.Announce("Chao mung ban den voi vong "+ level);
        StartCoroutine(TimeWaiting(10));    
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
                    yield return new WaitForSeconds(0.7f);
                }
            }
            if (this.dataGameEnemy._roundList.IndexOf(round) < this.dataGameEnemy._roundList.Count-1)
            {
                yield return new WaitForSeconds(10);
                MapManager.instance.SetWarnningEnemySpawn(true);
                yield return new WaitForSeconds(5);
                MapManager.instance.SetWarnningEnemySpawn(false);
            }
        }
        this.isEndGame = true;
    }
    IEnumerator TimeWaiting(float time)
    {
        MapManager.instance.SetWarnningEnemySpawn(false);
        yield return new WaitForSeconds(5);
        MapManager.instance.SetWarnningEnemySpawn(true);
        yield return new WaitForSeconds(time-5);
        MapManager.instance.SetWarnningEnemySpawn(false);
        StartCoroutine(SpawnEnemy());
    }
   
    public void PauseGame()
    {
       Time.timeScale = 0;
    }
    public void ContinueGame()
    {
       Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        this.ChangeGameSpeed();
        if(this.isEndGame) if(!EnemyManager.instance.IsHaveEnemy()) this.EndGame();
    }
    void ChangeGameSpeed()
    {
        if (this.gameSpeed > 0)
        {
            Time.timeScale = this.gameSpeed;
            this.gameSpeed = -1;
        }
    }
    public void LoadScene(string name)
    {
        //SceneManager.LoadScene(name);
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        UILoadingScene.instance.ShowUI(operation);
    }
    public void UnLockLevel(int level)
    {
        if (level > 4) return;
        this.dataPlayerSO.UnLockLevel(level);
    }
    public void EndGame()
    {   
        UIResult.instance.ShowUI();
        this.PauseGame();
    }
}
    
