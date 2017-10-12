using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playGames : MonoBehaviour
{

    public Text displayed;
    public Text p1;
    public Text p2;
    public Text p3;
    public Text p4;

    public string Instructions;
    public int players;
    public GameObject intro;
    public GameObject options;
    public GameObject field;
    public GameObject field3;
    public GameObject field4;
    public bool makeMove = false;
    public int[] Field;
    public List<bool> r;
    public List<bool> r1;
    public List<bool> r2;
    public List<bool> r3;
    public List<bool> r4;

    public Texture one;
    public Texture two;
    public Texture three;
    public Texture four;
    public Texture five;
    public Texture six;
    public Texture seven;
    public Texture eight;
    public Texture nine;
    public Texture ten;
    public Texture eleven;
    public Texture twelve;
    public Texture thirteen;
    public Texture fourteen;
    public Texture fifthteen;
    public Texture none;

    bool isSetup;
    int winner;
    int player;
    int health;
    int resource;

    public struct playerInfo
    {
        public int x, y, z;
        public playerInfo(int health, int resource, int strength)
        {
            x = health;
            y = resource;
            z = strength;
        }
    }

    public playerInfo P1;
    public playerInfo P2;
    public playerInfo P3;
    public playerInfo P4;

    // Use this for initialization
    public void Start()
    {

        intro = GameObject.FindGameObjectWithTag("Intro");
        options = GameObject.FindGameObjectWithTag("options");
        field = GameObject.FindGameObjectWithTag("Field");
        field3 = GameObject.FindGameObjectWithTag("3field");
        field4 = GameObject.FindGameObjectWithTag("4field");
        Instructions = "(pay 1) flip any card on the field face up\n(pay 2) peak at any face down card " +
                "and leave it face down\n(pay 3) discard any card in any player's hand\n(gain 1) let your opponent peak at any 3 face down cards\n" +
                "(gain 2) let your opponent peak at any 5 face down cards\n(gain 4) reveal your card to your opponent\n (free) chose any card on the " +
                "field to be your card in battle\n(free) surrender; no defense but opponent does not gain resources\n(free) ready for battle; gain 3 if" +
                " you win battle\n (payment varies) battle; pay the value of your card to attack\n";
        displayed.text = "Hello, welcome to Saltline! The game where players\nuse limited resources to deplete their opponent's even more limited health. So how many players this time?";
        isSetup = false;
        winner = 0;
        player = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (players != 0 && !isSetup)
        {

            displayed.text = "Great, " + players + " players which means" +
                " the highest card is " + (3 * players + 3) + ". Please make" +
                " a move or click Instructions if this is your first time playing.";
            isSetup = true;
            intro.SetActive(false);

            if (players == 2)
            {
                P1 = new playerInfo(9, 20, 0);
                r1 = new List<bool>();
                for (int i = 0; i < 7; i++) { r1.Add(false); }
                p1.text = "player 1:\nHP: " + P1.x + "\nRP: " + P1.y;

                P2 = new playerInfo(9, 20, 0);
                r2 = new List<bool>();
                for (int i = 0; i < 7; i++) { r2.Add(false); }
                p2.text = "player 2:\nHP: " + P2.x + "\nRP: " + P2.y;

                field3.SetActive(false);
                field4.SetActive(false);
                r = new List<bool>();
                for (int i = 0; i < 7; i++) { r.Add(false); }
            }

            if (players == 3)
            {
                P1 = new playerInfo(12, 25, 0);
                r1 = new List<bool>();
                for (int i = 0; i < 10; i++) { r1.Add(false); }
                p1.text = "player 1:\nHP: " + P1.x + "\nRP: " + P1.y;

                P2 = new playerInfo(12, 25, 0);
                r2 = new List<bool>();
                for (int i = 0; i < 10; i++) { r2.Add(false); }
                p2.text = "player 2:\nHP: " + P2.x + "\nRP: " + P2.y;

                P3 = new playerInfo(12, 25, 0);
                r3 = new List<bool>();
                for (int i = 0; i < 10; i++) { r3.Add(false); }
                p3.text = "player 3:\nHP: " + P3.x + "\nRP: " + P3.y;

                field4.SetActive(false);
                r = new List<bool>();
                for (int i = 0; i < 10; i++) { r.Add(false); }
            }

            if (players == 4)
            {
                P1 = new playerInfo(15, 30, 0);
                r1 = new List<bool>();
                for (int i = 0; i < 13; i++) { r1.Add(false); }
                p1.text = "player 1:\nHP: " + P1.x + "\nRP: " + P1.y;

                P2 = new playerInfo(15, 30, 0);
                r2 = new List<bool>();
                for (int i = 0; i < 13; i++) { r2.Add(false); }
                p2.text = "player 2:\nHP: " + P2.x + "\nRP: " + P2.y;

                P3 = new playerInfo(15, 30, 0);
                r3 = new List<bool>();
                for (int i = 0; i < 13; i++) { r3.Add(false); }
                p3.text = "player 3:\nHP: " + P3.x + "\nRP: " + P3.y;

                P4 = new playerInfo(15, 30, 0);
                r4 = new List<bool>();
                for (int i = 0; i < 13; i++) { r4.Add(false); }
                p4.text = "player 4:\nHP: " + P4.x + "\nRP: " + P4.y;

                r = new List<bool>();
                for (int i = 0; i < 13; i++) { r.Add(false); }

            }
            field.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            options.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            startRound(players);
        }
        /*
        if (players != 0 && winner == 0)
        {
            player++;
            if (player > players) { player = 1; }
            moveNow(player, players);
            winner = -1;
        }*/

    }

    void startRound(int totalPlayers)
    {
        int totalCards = 3 * totalPlayers + 3;
        int numCards = totalCards - 2;
        List<int> candidates = new List<int>();
        Field = new int[numCards];
        System.Random rand = new System.Random();

        for (int i = 1; i <= totalCards; i++)
        {
            candidates.Add(i);
        }

        for (int j = 0; j < numCards; j++)
        {
            int numChosen = candidates[rand.Next(0, candidates.Count)];
            Field[j] = numChosen;
            //Debug.Log(Field[j]);
            candidates.Remove(numChosen);
        }
    }
}
    /*
    void moveNow(int firstPlayer, int totalPlayers) {
        
        switch (firstPlayer)
        {
            //case 1: playerList = r1;
                //break;
        }
    }

}*/
