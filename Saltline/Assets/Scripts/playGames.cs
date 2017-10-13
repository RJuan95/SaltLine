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
    public Text result;

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

    public Material one1;
    public Material two1;
    public Material three1;
    public Material four1;
    public Material five1;
    public Material six1;
    public Material seven1;
    public Material eight1;
    public Material nine1;
    public Material ten1;
    public Material eleven1;
    public Material twelve1;
    public Material thirteen1;

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
        resetCards();
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
        displayed.text = "\n\n\n\nHello, welcome to Saltline where Rival kingdoms have waged war and are now in need of mercenarys for hire. Playing as the " +
            "kingdom's leaders, hire mercenarys to attack your Rival(s) and deplete all their HP (kingdom's health). The stronger the mercenary, the more they cost." +
            " If you don't have enough money to hire your mercenary, they will abandon you and leave you vulnerable to a full attack. Remember though, You don't have " +
            "to pay a mercenary if they don't survive the battle. Find the right strategies and risks to eliminate every other rival and secure your legendary victory.\n\nSo how many players this time?";
        isSetup = false;
        winner = 0;
        player = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (players != 0 && !isSetup)
        {

            displayed.text = "Great, " + players + " players meaning" +
                " highest card (strongest mercenary) is " + (3 * players + 3) + ". Make" +
                " a move by clicking on an action button and " +
                "card.\nActions: Pay 2 coins to reveal a card, gain " +
                "1 coin (max 4 per round), pay 1 coin to pass or pick ally (hire a mercenary).\nHire " +
                "a mercenary when the time is right and then wait for everyone else to hire theirs. " +
                "Once everyone has a mercenary, all mercenaries go to battle. The losers of the battle " +
                "lose HP according to the difference between the strongest mercanary and their own. The " +
                "victor must pay their mercenary's respective value however for the victory. A new round then starts and the game " +
                "continues this loop until only one kingdom remains standing.";
            isSetup = true;
            intro.SetActive(false);

            if (players == 2)
            {
                P1 = new playerInfo(9, 20, 0);
                r1 = new List<bool>();
                for (int i = 0; i < 7; i++) { r1.Add(false); }
                p1.text = "player 1:\nHP: " + P1.x + "\nCoins: " + P1.y;

                P2 = new playerInfo(9, 20, 0);
                r2 = new List<bool>();
                for (int i = 0; i < 7; i++) { r2.Add(false); }
                p2.text = "player 2:\nHP: " + P2.x + "\nCoins: " + P2.y;

                P3 = new playerInfo(0, 0, 0);
                P4 = new playerInfo(0, 0, 0);
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
                p1.text = "player 1:\nHP: " + P1.x + "\nCoins: " + P1.y;

                P2 = new playerInfo(12, 25, 0);
                r2 = new List<bool>();
                for (int i = 0; i < 10; i++) { r2.Add(false); }
                p2.text = "player 2:\nHP: " + P2.x + "\nCoins: " + P2.y;

                P3 = new playerInfo(12, 25, 0);
                r3 = new List<bool>();
                for (int i = 0; i < 10; i++) { r3.Add(false); }
                p3.text = "player 3:\nHP: " + P3.x + "\nCoins: " + P3.y;

                P4 = new playerInfo(0, 0, 0);
                field4.SetActive(false);
                r = new List<bool>();
                for (int i = 0; i < 10; i++) { r.Add(false); }
            }

            if (players == 4)
            {
                P1 = new playerInfo(15, 30, 0);
                r1 = new List<bool>();
                for (int i = 0; i < 13; i++) { r1.Add(false); }
                p1.text = "player 1:\nHP: " + P1.x + "\nCoins: " + P1.y;

                P2 = new playerInfo(15, 30, 0);
                r2 = new List<bool>();
                for (int i = 0; i < 13; i++) { r2.Add(false); }
                p2.text = "player 2:\nHP: " + P2.x + "\nCoins: " + P2.y;

                P3 = new playerInfo(15, 30, 0);
                r3 = new List<bool>();
                for (int i = 0; i < 13; i++) { r3.Add(false); }
                p3.text = "player 3:\nHP: " + P3.x + "\nCoins: " + P3.y;

                P4 = new playerInfo(15, 30, 0);
                r4 = new List<bool>();
                for (int i = 0; i < 13; i++) { r4.Add(false); }
                p4.text = "player 4:\nHP: " + P4.x + "\nCoins: " + P4.y;

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

    public void startRound(int totalPlayers)
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

    public void resetCards()
    {
        one1.mainTexture = none;
        two1.mainTexture = none;
        three1.mainTexture = none;
        four1.mainTexture = none;
        five1.mainTexture = none;
        six1.mainTexture = none;
        seven1.mainTexture = none;
        eight1.mainTexture = none;
        nine1.mainTexture = none;
        ten1.mainTexture = none;
        eleven1.mainTexture = none;
        twelve1.mainTexture = none;
        thirteen1.mainTexture = none;

        one1.color = Color.white;
        two1.color = Color.white; 
        three1.color = Color.white;
        four1.color = Color.white;
        five1.color = Color.white;
        six1.color = Color.white;
        seven1.color = Color.white;
        eight1.color = Color.white;
        nine1.color = Color.white;
        ten1.color = Color.white;
        eleven1.color = Color.white;
        twelve1.color = Color.white;
        thirteen1.color = Color.white;
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
