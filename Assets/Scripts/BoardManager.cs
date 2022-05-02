using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private Enemy EnemyPrefab;
    [SerializeField] private TextMeshProUGUI _MenuText;
    [SerializeField] private TextMeshProUGUI respect;
    public GameObject Screen1;
    public GameObject Screen2;
    public GameObject GameScreen;
    public GameObject Board;
    public GameObject Endscreens;

    private Grid grid;
    private Player player;
    private Enemy enemy;
    private Enemy enemy2;
    private Enemy enemy3;
    private Enemy enemy4;
    private int N;
    //[SerializeField] private float moveSpeed = 2f;
    public int tri = 0;
    public int val;
    public static int Level = 1;
    public int started = 0;
    public int resp = 0;
    public int deathcont = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        if (MainMenu.N==0)
        {
            N = 12;
        }
        else
        {
            N = MainMenu.N;
        }
        if(tri==0)
        {
            grid = new Grid(N, N, 1, CellPrefab);
            player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);
            SpawnEnemy(Level);

        }
        if(tri==1)
        {
            grid = new Grid(N, N, 1, CellPrefab);

        }
        
        bool ver=VerifyPath();
        if (ver==false)
        {
            tri = 1;
            Start();
        }
        
    }
    public void SpawnEnemy(int x)
    {
        if (x == 1)
        {
            enemy = Instantiate(EnemyPrefab, new Vector2(0, N - 1), Quaternion.identity);
        }
        if (x == 2)
        {
            enemy2 = Instantiate(EnemyPrefab, new Vector2(N - 1, 0), Quaternion.identity);
        }
        if (x == 3)
        {
            enemy3 = Instantiate(EnemyPrefab, new Vector2(N - 5, 5), Quaternion.identity);
        }
        if (x == 4)
        {
            enemy4 = Instantiate(EnemyPrefab, new Vector2(0, N-5), Quaternion.identity);
        }

    }
 
    
    public void NextLevel()
    {
        ResetEnemy(enemy, enemy2, enemy3, enemy4, Level);
        val = int.Parse(_MenuText.text);
        val++;
        Level = val;
        resp = resp + 99;
        respect.text = resp.ToString();

        SpawnEnemy(Level);
        _MenuText.text = val.ToString();
        StartCoroutine(LevelDelay(Screen1));
        if(Level==5)
        {
            Level = 4;

            GameScreen.SetActive(false);
            Board.SetActive(false);
            Endscreens.SetActive(true);
            
        }
        
    }

    IEnumerator LevelDelay(GameObject screenV)
    {
        //TimerController.instance.EndTimer();

        //Endscreen.instance.SetTime();

        screenV.SetActive(true);
        yield return new WaitForSeconds(2);
        screenV.SetActive(false);
        
        //TimerController.instance.BeginTimer();
    }

    

    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);
        player.SetPath(path);
    }
    public void EnemyFindPath(int x, int y, Enemy VEnemy)
    {
        //Debug.Log("Enemy :" + (int)enemy.GetPosition.x + "   " + (int)enemy.GetPosition.y + "Player: "+ x+"   " + y);
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)VEnemy.GetPosition.x, (int)VEnemy.GetPosition.y, x, y);
        VEnemy.SetPath(path);
    }

    public bool VerifyPath()
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, N-1, N-1);
        if(path==null)
        {
            return false;
        }
        else { return true; }
        
    }
    public void ResetEnemy(Enemy VEnemy, Enemy VEnemy2, Enemy VEnemy3, Enemy VEnemy4, int x)
    {
        if (x == 1)
        {
            VEnemy.ResetPosition(0, N - 1);
            List<Cell> path = PathManager.Instance.FindPath(grid, (int)VEnemy.GetPosition.x, (int)VEnemy.GetPosition.y, 0, N-1);
            VEnemy.SetPath(path);

        }
        if (x == 2)
        {
            VEnemy.ResetPosition(0, N - 1);
            List<Cell> path = PathManager.Instance.FindPath(grid, (int)VEnemy.GetPosition.x, (int)VEnemy.GetPosition.y, 0, N - 1);
            VEnemy.SetPath(path);
            VEnemy2.ResetPosition(N - 1, 0);
            List<Cell> path2 = PathManager.Instance.FindPath(grid, (int)VEnemy2.GetPosition.x, (int)VEnemy2.GetPosition.y, N - 1, 0);
            VEnemy2.SetPath(path2);

        }
        if (x == 3)
        {
            VEnemy.ResetPosition(0, N - 1);
            List<Cell> path = PathManager.Instance.FindPath(grid, (int)VEnemy.GetPosition.x, (int)VEnemy.GetPosition.y, 0, N - 1);
            VEnemy.SetPath(path);
            VEnemy2.ResetPosition(N - 1, 0);
            List<Cell> path2 = PathManager.Instance.FindPath(grid, (int)VEnemy2.GetPosition.x, (int)VEnemy2.GetPosition.y, N - 1, 0);
            VEnemy2.SetPath(path2);
            VEnemy3.ResetPosition(N - 5, 5);
            List<Cell> path3 = PathManager.Instance.FindPath(grid, (int)VEnemy3.GetPosition.x, (int)VEnemy3.GetPosition.y, N - 5, 5);
            VEnemy3.SetPath(path3);
        }
        if (x == 4)
        {
            VEnemy.ResetPosition(0, N - 1);
            List<Cell> path = PathManager.Instance.FindPath(grid, (int)VEnemy.GetPosition.x, (int)VEnemy.GetPosition.y, 0, N - 1);
            VEnemy.SetPath(path);
            VEnemy2.ResetPosition(N - 1, 0);
            List<Cell> path2 = PathManager.Instance.FindPath(grid, (int)VEnemy2.GetPosition.x, (int)VEnemy2.GetPosition.y, N - 1, 0);
            VEnemy2.SetPath(path2);
            VEnemy3.ResetPosition(N - 5, 5);
            List<Cell> path3 = PathManager.Instance.FindPath(grid, (int)VEnemy3.GetPosition.x, (int)VEnemy3.GetPosition.y, N - 5, 5);
            VEnemy3.SetPath(path3);
            VEnemy4.ResetPosition(0, 5);
            List<Cell> path4 = PathManager.Instance.FindPath(grid, (int)VEnemy4.GetPosition.x, (int)VEnemy4.GetPosition.y, 0, 5);
            VEnemy4.SetPath(path4);
        }
    }
    IEnumerator Delay(Enemy VEnemy, Enemy VEnemy2, Enemy VEnemy3, Enemy VEnemy4, int level)
    {
        yield return new WaitForSeconds(1);
        Hunt((int)player.GetPosition.x + 1, (int)player.GetPosition.y, enemy, enemy2, enemy3, enemy4, Level);
    }
    IEnumerator CheckReset()
    {      
        yield return new WaitForSeconds(1);
        ResetEnemy(enemy, enemy2, enemy3, enemy4, Level);
    }
    IEnumerator EndGame()
    {
        Screen2.SetActive(true);
        yield return new WaitForSeconds(2);
        Screen2.SetActive(false);
        GameScreen.SetActive(false);
        Board.SetActive(false);
        Endscreens.SetActive(true);
    }

    public void CheckDeath(Enemy VEnemy, Enemy VEnemy2, Enemy VEnemy3, Enemy VEnemy4, int level)
    {
        if (level == 1)
            {
                if (Death(player, VEnemy) == true)
                {
                
                    if(deathcont==0)
                        {
                            StartCoroutine(EndGame());
                            deathcont = 1;
                        }
                       
                    //ResetEnemy(Level);
                
                    Debug.Log("Death");
                }
            }
        if (level == 2)
            {
                if ((Death(player, VEnemy) == true) || (Death(player, VEnemy2) == true))
                {
                    if (deathcont == 0)
                    {
                        StartCoroutine(EndGame());
                        deathcont = 1;
                    }
                Debug.Log("Death");
                }
            }
        if (level == 3)
            {
                if ((Death(player, VEnemy) == true)||(Death(player, VEnemy2) == true)||(Death(player, VEnemy3) == true))
                {
                    if (deathcont == 0)
                    {
                        StartCoroutine(EndGame());
                        deathcont = 1;
                    }
                Debug.Log("Death");
                }
            }
        if (level == 4)
            {
                if ((Death(player, VEnemy) == true) || (Death(player, VEnemy2) == true) || (Death(player, VEnemy3) == true) || (Death(player, VEnemy4) == true))
                {
                    if (deathcont == 0)
                    {
                        StartCoroutine(EndGame());
                        deathcont = 1;
                    }
                Debug.Log("Death");
                }
            }


    }

    public void Hunt(int x, int y, Enemy VEnemy, Enemy VEnemy2, Enemy VEnemy3, Enemy VEnemy4, int level)
    {
        if(level==1)
            {
                EnemyFindPath(x, y, VEnemy);
            }
        if (level == 2)
            {
                EnemyFindPath(x, y, VEnemy);
                EnemyFindPath(x, y, VEnemy2);
            }
        if (level == 3)
            {
                EnemyFindPath(x, y, VEnemy);
                EnemyFindPath(x, y, VEnemy2);
                EnemyFindPath(x, y, VEnemy3);
            }
        if (level == 4)
            {
                EnemyFindPath(x, y, VEnemy);
                EnemyFindPath(x, y, VEnemy2);
                EnemyFindPath(x, y, VEnemy3);
                EnemyFindPath(x, y, VEnemy4);
            }
        
    }
    public bool Death(Player Pplayer, Enemy PEnemy)
        {
           if(((int)Pplayer.GetPosition.x == (int)PEnemy.GetPosition.x)&&((int)Pplayer.GetPosition.y == (int)PEnemy.GetPosition.y))
                    {
                return true;
            }
           else
            {
                return false;
            }
        }
   
    void Update()
    {

        CheckDeath(enemy, enemy2, enemy3, enemy4, Level);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            started++;
            CellMouseClick((int)player.GetPosition.x+1, (int)player.GetPosition.y);
            //StartCoroutine(Delay(enemy, enemy2, enemy3, enemy4, Level));
            Hunt((int)player.GetPosition.x+1, (int)player.GetPosition.y, enemy, enemy2 , enemy3, enemy4, Level);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            started++;
            CellMouseClick((int)player.GetPosition.x - 1, (int)player.GetPosition.y);
            Hunt((int)player.GetPosition.x - 1, (int)player.GetPosition.y, enemy, enemy2, enemy3, enemy4, Level);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            started++;
            CellMouseClick((int)player.GetPosition.x, (int)player.GetPosition.y+1);
            Hunt((int)player.GetPosition.x, (int)player.GetPosition.y+1, enemy, enemy2, enemy3, enemy4, Level);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            started++;
            CellMouseClick((int)player.GetPosition.x, (int)player.GetPosition.y-1);
            Hunt((int)player.GetPosition.x, (int)player.GetPosition.y-1, enemy, enemy2, enemy3, enemy4, Level);
        }
        if (started == 1)
        {
            Debug.Log("hola");
            TimerController.instance.BeginTimer();
            started = 2;
        }

        
    }
}
