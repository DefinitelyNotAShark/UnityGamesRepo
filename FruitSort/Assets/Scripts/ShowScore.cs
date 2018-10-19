using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    [SerializeField]
    Text scoreText;

    string rank;

    int thisScore;
    int lastScore;
    // Use this for initialization
    void Start()
    {
        SaveScore.Save();//saves your score for the game
        scoreText.text = "Your score is " + GameData.points.ToString() + " fruit.";
        thisScore = GameData.points;

       if(thisScore <= 5)//from 0 to 5
        {
            rank = "Blind Monkey";
        }
       else if(thisScore > 6 && thisScore < 15)//from 6 to 15
        {
            rank = "Unpaid Intern";
        }
        else if (thisScore >= 15 && thisScore < 25)//from 15 to 24
        {
            rank = "Minimum Wage Worker";
        }
        else if (thisScore >= 25 && thisScore < 32)//from 25 to 32
        {
            rank = "Office Associate";
        }
        else if (thisScore >= 32 && thisScore < 39)//from 32 to 39
        {
            rank = "Store Manager";
        }
        else if (thisScore >= 40)//from 40 to 45
        {
            rank = "CEO";
        }
        scoreText.text = scoreText.text + "\n\nYour Rank: " + rank;

        //lastScore = thisScore;
    }


        //SaveScore.LoadScore();//set the last score to the last saved score
        //lastScore = GameData.points;
        //if (SaveScore.savedGames.Count == 0 || thisScore > lastScore)
        //{
        //    // if there is no score recorded or yours is bigger, your score is the high score
        //    topScore = thisScore;
        //}
        //else
        //    topScore = lastScore;

        //scoreText.text = scoreText.text + "\n\nHigh score: " + topScore;

        //you know what??? I tried to do a save/load for 4 hours. I have other things to do. 
        //the code that I tried is there. You can see my efforts. 
        //I freakin did a buncha googling and tried changing a bunch of properties.
        //I can't do stuff that keeps previous progress out of game. I just can't right now.
        //It's 10 at night and i need to eat dinner.
        //sophie out.
}
