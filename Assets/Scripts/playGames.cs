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

    bool isSetup = false;

    // Use this for initialization
    public void Start()
    {
        intro = GameObject.FindGameObjectWithTag("Intro");
       

        displayed.text = "Hello, welcome to Saltline!";
        int winner = 0;
        int player = 0;
        /*
        while (players == 0)
        {
            players = Setup();
        }

        while (winner != 0)
        {
            player++;
            if (player > players) { player = 1; }
            startRound(player, players);
        }
        startRound(player, players);*/
    }

    int Setup()
    {
        /*
        int numPlayers;
        string input = "";
        textDisplay = "Please click the number of players (2-4)";
        getline(cin, input);
        stringstream myStream(input);
        myStream >> numPlayers;
        if ((numPlayers < 5) && (numPlayers > 1))
        {
            cout << "Great, " << numPlayers << " players it is!" << endl;
            return numPlayers;
        }
        else
        {
            cout << "Sorry that's not a valid response. Try again." << endl;
            return 0;
        }*/
        return 0;
    }

    void startRound(int firstPlayer, int totalPlayers)
    {
        /*
        srand(time(NULL));
        int totalCards = 3 * totalPlayers + 3;
        int numCards = totalCards - 2;
        vector<int> candidates;
        vector<int> field;

        for (int i = 1; i <= totalCards; i++)
        {
            candidates.push_back(i);
        }
        for (int i = 0; i < numCards; i++)
        {
            int numChosen = rand() % (totalCards - i);
            field.push_back(candidates[numChosen]);
            candidates.erase(candidates.begin() + numChosen);
            cout << field[i] << " ";
        }
        cout << endl;*/
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
    }
}
