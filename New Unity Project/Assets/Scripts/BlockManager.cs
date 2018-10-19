using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BlockManager : MonoBehaviour
{
    public GameObject normalPrefab;
    public GameObject crackPrefab;
    public GameObject twiceCrackPrefab;
    public GameObject paddlePowerUpPrefab;

    public float gridX = 5f;

    public float gridY = 5f;
    public float padding = .05f;

    public float startX = -1; //unity units startX
    public float starty = 1; //unity units startY

    private List<GameObject> Bricks;
    private List<GameObject> bricksToRemove;

    private GameObject thisPrefab;

    int chanceOfPowerup;

    void Start()
    {
        if(ScoreManager.Level == 1)
        {
            gridY = 3;
        }
        this.LoadLevel();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(new Vector3((startX + gridX) / 2, (starty + gridY) /2), new Vector3(gridX, gridY, 0));
    }

    public virtual void LoadLevel()//this would be the place to add blocks
    {
        Bricks = new List<GameObject>();//list of bricks
        bricksToRemove = new List<GameObject>();//list of bricks to destroy
        ChangeBlocksBasedOnLevel();
    }

    void ChangeBlocksBasedOnLevel()
    {
        if(ScoreManager.Level == 1)//level 1 block setup. All normal except the ends are powerupBlocks
        {
            for (float y = starty; y < gridY; y = y + padding)//create a y grid
            {
                for (float x = startX; x < gridX; x = x + padding)//create an x grid
                {
                    Vector3 pos = new Vector3(x + padding, y + padding, 0);//set the position at the x and y
                    chanceOfPowerup = Random.Range(0, 16);

                    if (chanceOfPowerup == 1)//if the block is the first one
                        thisPrefab = paddlePowerUpPrefab;//then set it to the power up...

                    else
                        thisPrefab = normalPrefab;

                    var brick = Instantiate(thisPrefab, pos, Quaternion.identity, this.transform);//create a new brick at that position and parent it to the brick
                    Bricks.Add(brick);
                }
            }
        }
        else if(ScoreManager.Level == 2)
        {
            for (float y = starty; y < gridY; y = y + padding)//create a y grid
            {
                for (float x = startX; x < gridX; x = x + padding)//create an x grid
                {
                    Vector3 pos = new Vector3(x + padding, y + padding, 0);//set the position at the x and y
                    chanceOfPowerup = Random.Range(0, 16);

                    if (y == starty)
                    {
                        thisPrefab = crackPrefab;
                    }

                    else if(chanceOfPowerup == 1)
                    {
                        thisPrefab = paddlePowerUpPrefab;
                    }

                    else
                    {
                        thisPrefab = normalPrefab;
                    }             

                    var brick = Instantiate(thisPrefab, pos, Quaternion.identity, this.transform);//create a new brick at that position and parent it to the brick
                    Bricks.Add(brick);
                }
            }
        }
        else if(ScoreManager.Level == 3)
        {
            {
                for (float y = starty; y < gridY; y = y + padding)//create a y grid
                {
                    for (float x = startX; x < gridX; x = x + padding)//create an x grid
                    {
                        Vector3 pos = new Vector3(x + padding, y + padding, 0);//set the position at the x and y
                        chanceOfPowerup = Random.Range(0, 16);

                        if (y == starty)
                        {
                            thisPrefab = twiceCrackPrefab;
                        }

                        else if (chanceOfPowerup > 11)
                        { 
                            thisPrefab = crackPrefab;
                        }

                        else if (chanceOfPowerup == 1)
                        {
                            thisPrefab = paddlePowerUpPrefab;
                        }

                        else
                        {                          
                            thisPrefab = normalPrefab;
                        }

                        var brick = Instantiate(thisPrefab, pos, Quaternion.identity, this.transform);//create a new brick at that position and parent it to the brick
                        Bricks.Add(brick);
                    }
                }
            }
        }
    }

    //Win
    void Win()
    {
        SceneManager.LoadScene(1);
    }

    void Lose()
    {
        SceneManager.LoadScene(2);
    }
    void Update()
    {
        bricksToRemove.Clear();
        foreach (var item in Bricks)
        {
            if (item == null)
            {
                bricksToRemove.Add(item);
            }
        }

        foreach (var item in bricksToRemove)
        {
            Bricks.Remove(item);
            ScoreManager.Score += 1;
        }

        if (Bricks.Count == 0)//this doesnt even work yet....
        {
            if(ScoreManager.Level == 3)
            {
                Win();
            }
            if (ScoreManager.Level == 2 || ScoreManager.Level == 3)
            {
                gridY = 4;
            }
            ScoreManager.Level++;
            ScoreManager.Lives = 3;//resets lives because im nice
            LoadLevel();
        }
    }

    private void FixedUpdate()
    {
        CheckIfLose();
    }

    void CheckIfLose()
    {
        if(ScoreManager.Lives < 0)
        {
            Lose();
        }
    }
}
