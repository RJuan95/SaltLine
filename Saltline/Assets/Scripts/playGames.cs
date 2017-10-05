using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playGames : MonoBehaviour
{

    public Text displayed;
    public int players = 0;
    public GameObject intro;

    bool isSetup;
    int winner;
    int player;

    // Use this for initialization
    public void Start()
    {

        intro = GameObject.FindGameObjectWithTag("Intro");
        displayed.text = "Hello, welcome to Saltline!";
        isSetup = false;
        winner = 0;
        player = 0;
 
    }

    // Update is called once per frame
    void Update()
    {
        if (players != 0 && !isSetup)
        {
            displayed.text = "Great, " + players + " players today!";
            isSetup = true;
            intro.SetActive(false);
        }

        if (players != 0 && winner == 0)
        {
            player++;
            if (player > players) { player = 1; }
            startRound(player, players);
            winner = -1;
        }
       
    }

    void startRound(int firstPlayer, int totalPlayers)
    {

        int totalCards = 3 * totalPlayers + 3;
        int numCards = totalCards - 2;
        List<int> candidates = new List<int>();
        int[] field = new int[numCards];
        System.Random rand = new System.Random();

        for (int i = 1; i <= totalCards; i++)
        {
            candidates.Add(i);
        }

        for (int j = 0; j < numCards; j++)
        {
            int numChosen = candidates[rand.Next(0, candidates.Count)];
            field[j] = numChosen;
            candidates.Remove(numChosen);
        }

    }
}
