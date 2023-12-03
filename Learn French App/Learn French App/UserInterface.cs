using Learn_French_App.DAO;
using Learn_French_App.Models;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;

namespace Learn_French_App
{
    public class UserInterface
    {
        //todo - breakup content into smaller pieces to grab with API
        Content content = new Content();
        ContentDao contentDao = new ContentDao();
        Dictionary<int, Dictionary<int, FlashCardInfo>> currentContent = new Dictionary<int, Dictionary<int, FlashCardInfo>>();

        public void Run()
        {
            Greeting();
            content = contentDao.GetVocab();

            //set to make sure loop runs
            bool isMenuDone = false;

            //main menu of app -> choose unit
            while (!isMenuDone)
            {
                MainMenu();

                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        currentContent = content.IntroContent;
                        DisplayTopicMenu();
                        break;
                    case "2":
                        currentContent = content.PlansContent;
                        DisplayTopicMenu();
                        break;
                    case "3":
                        currentContent = content.RestoContent;
                        DisplayTopicMenu();
                        break;
                    case "4":
                        currentContent = content.InterestsContent;
                        DisplayTopicMenu();
                        break;
                    case "E":
                        isMenuDone = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid value.");
                        Console.WriteLine();
                        break;
                }

            }
        }

        //todo -> create display menu switches
        public void DisplayTopicMenu()
        {

            bool isMenuDone = false;

            while (!isMenuDone)
            {
                TopicMenu();

                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        LearnToSpellALLVocab();
                        break;
                    case "2":
                        PracticeSentences(currentContent[3]);
                        break;
                    case "3":
                        //todo: implement chat GPT API
                        //ConversationSimulation();
                        break;
                    case "R":
                    case "r":
                        isMenuDone = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid value.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private void Greeting()
        {
            Console.WriteLine("Bonjour et bienvenue");
            Console.WriteLine("Hello and welcome");
        }

        private void MainMenu()
        {
            //display main menu
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            Console.WriteLine("Please select your topic:");

            Console.WriteLine("1 - Meeting someone new");
            Console.WriteLine("2 - Making plans");
            Console.WriteLine("3 - At a restaurant");
            Console.WriteLine("4 - Discussing interests");
            Console.WriteLine("E - Exit the application");
        }

        //todo add current topic variable
        private void TopicMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Activities Menu");
            Console.WriteLine();
            Console.WriteLine("Please select your activity:");
            Console.WriteLine("1 - Learn vocabulary");
            Console.WriteLine("2 - Practice sentences");
            Console.WriteLine("3 - Conversation simulation");
            Console.WriteLine("R - Return to previous menu");
        }

        public void LearnToSpellALLVocab()
        {
            foreach (KeyValuePair<int, Dictionary<int, FlashCardInfo>> dictionary in currentContent)
            {
                if (dictionary.Key != 4)
                {
                    LearnToSpellVocab(dictionary.Value);
                    TestVocabKnowledge(dictionary.Value);
                }
            }
        }

        //accessed through IUnit
        public void LearnToSpellVocab(Dictionary<int, FlashCardInfo> currentDictionary)
        {
            bool canSpellVocab = false;

            //teach them how to spell words
            while (canSpellVocab == false)
            {
                Console.WriteLine();
                Console.WriteLine("It's time to learn some vocab! Please type carefully.");
                Console.WriteLine("Typing or writing a word 5 times makes you more likely to remember it.");
                Console.WriteLine("You're even more likely to remember it if you say the word outloud while you write.");
                Console.WriteLine("Enter \"E\" at any time to escape the activty and return to the Activities Menu.");
                Console.WriteLine();

                foreach (KeyValuePair<int, FlashCardInfo> currentElement in currentDictionary)
                {
                    FlashCardInfo currentFlashCard = currentElement.Value;

                    //tells user the word in English(Key) and French(Value)
                    Console.WriteLine();
                    Console.WriteLine($"\"{currentFlashCard.English}\" in French is \"{currentFlashCard.French}\"");
                    Console.WriteLine();

                    int wordCounter = 0;

                    //user needs to write the word 5 times
                    while (wordCounter < 5)
                    {
                        Console.WriteLine($"{wordCounter}/5: Type the word \"{currentFlashCard.French}\" exactly as it appears.");
                        string userInputLearn = Console.ReadLine();

                        if (userInputLearn == "E")
                        {
                            return;
                        }

                        //if they get the word wrong, prompt them until they get it right
                        while (currentFlashCard.French != userInputLearn)
                        {
                            Console.WriteLine("Please try again.");
                            Console.WriteLine($"{wordCounter}/5: Type the word \"{currentFlashCard.French}\" exactly as it appears.");
                            userInputLearn = Console.ReadLine();

                            if (userInputLearn == "E")
                            {
                                return;
                            }
                        }

                        //count how many times they get the word right to escape while
                        //and move onto next word
                        if (currentFlashCard.French == userInputLearn)
                        {
                            wordCounter++;
                        }

                        if (wordCounter == 5)
                        {
                            Console.WriteLine("5/5 Excellent !");
                        }


                    }
                }
                Console.WriteLine();
                Console.WriteLine("Felicitations ! You learned all the words in this list!");
                Console.WriteLine();
                canSpellVocab = true;
            }
        }

        //todo - change input
        public void TestVocabKnowledge(Dictionary<int, FlashCardInfo> currentDictionary)
        {
            bool isVocabLearned = false;

            //test to see what they remember
            while (!isVocabLearned)
            {
                Console.Clear();
                Console.WriteLine("You will now be asked to remember the words you just learned.");
                Console.WriteLine("Enter \"E\" at any time to escape the activty and return to the Activities Menu.");
                Console.WriteLine();

                foreach (KeyValuePair<int, FlashCardInfo> currentElement in currentDictionary)
                {
                    FlashCardInfo currentFlashCard = currentElement.Value;

                    Console.WriteLine();
                    Console.WriteLine($"What is \"{currentFlashCard.English}\" in French?");
                    string userVocabInput = Console.ReadLine();

                    if (userVocabInput == "E")
                    {
                        return;
                    }

                    while (userVocabInput != currentFlashCard.French)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please try again.");
                        Console.WriteLine($"What is \"{currentFlashCard.English}\" in French?");
                        userVocabInput = Console.ReadLine();

                        if (userVocabInput == "E")
                        {
                            return;
                        }
                    }

                }

                Console.WriteLine();
                Console.WriteLine("Felicitations ! You remebered all the vocab!");
                Console.WriteLine();
                isVocabLearned = true;
            }

        }

        public void PracticeSentences(Dictionary<int, FlashCardInfo> currentDictionary)
        {

            bool isSentenceBuildingFin = false;

            //test to see what they remember
            while (!isSentenceBuildingFin)
            {
                Console.Clear();

                Console.WriteLine("You will now be asked to combine some of what you learned into sentences.");
                Console.WriteLine("Enter \"E\" at any time to escape the activty and return to the Activities Menu.");
                Console.WriteLine();

                foreach (KeyValuePair<int, FlashCardInfo> currentElement in currentDictionary)
                {
                    FlashCardInfo currentFlashCard = currentElement.Value;

                    Console.WriteLine();
                    Console.WriteLine($"What is \"{currentFlashCard.English}\" in French?");
                    string userVocabInput = Console.ReadLine();

                    if (userVocabInput == "E")
                    {
                        return;
                    }

                    while (userVocabInput != currentFlashCard.French)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please try again.");
                        Console.WriteLine($"What is \"{currentFlashCard.English}\" in French?");
                        userVocabInput = Console.ReadLine();

                        if (userVocabInput == "E")
                        {
                            return;
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Felicitations ! You remebered all the vocab!");
                Console.WriteLine();
                isSentenceBuildingFin = true;
            }
        }
    }
}
