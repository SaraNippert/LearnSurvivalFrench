using Microsoft.VisualBasic;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Learn_French_App.Models
{
    public class Content
    {
        //Tracking Completion

        //Unit 1: Introductions
        public bool IsIntroGreetingsDone { get; set; }
        public bool IsIntroMoodDone { get; set; }
        public bool IsIntroNamesDone { get; set; }
        public bool IsIntroSentencesDone { get; set; }

        //Unit 2: Plans
        public bool IsPlansBaseDone { get; set; }
        public bool IsPlansPlacesDone { get; set; }
        public bool IsPlansFrequencyDone { get; set; }
        public bool IsPlansSentencesDone { get; set; }

        //Unit 3: Resto
        public bool IsRestoHostStandDone { get; set; }
        public bool IsRestoForHereDone { get; set; }
        public bool IsRestoFoodDone { get; set; }
        public bool IsRestoSentencesDone { get; set; }

        //todo - Unit 4: Interests
        public bool IsInterestsBaseDone { get; set; }
        public bool IsInterestsPositiveDone { get; set; }
        public bool IsInterestsNegativeDone { get; set; }
        public bool IsInterestsSentencesDone { get; set; }


        //Dictionaries

        //Unit 1: Introductions
        public Dictionary<int, FlashCardInfo> IntroGreetings { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> IntroMood { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> IntroNames { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> IntroSentences { get; set; } = new Dictionary<int, FlashCardInfo>();

        public Dictionary<int, Dictionary<int, FlashCardInfo>> IntroContent
        {
            get {

                Dictionary<int, Dictionary<int, FlashCardInfo>> IntroContent= new Dictionary<int, Dictionary<int, FlashCardInfo>>(){
                    {1, IntroGreetings },
                    {2, IntroMood },
                    {3, IntroNames },
                    {4, IntroSentences }
                };
                return IntroContent;
            }
        }


        //Unit 2: Plans
        public Dictionary<int, FlashCardInfo> PlansBase { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> PlansPlaces { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> PlansFrequency { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> PlansSentences { get; set; } = new Dictionary<int, FlashCardInfo>();

        public Dictionary<int, Dictionary<int, FlashCardInfo>> PlansContent
        {
            get
            {

                Dictionary<int, Dictionary<int, FlashCardInfo>> PlansContent = new Dictionary<int, Dictionary<int, FlashCardInfo>>(){
                    {1, PlansBase },
                    {2, PlansPlaces },
                    {3, PlansFrequency },
                    {4, PlansSentences }
                };
                return PlansContent;
            }
        }


        //Unit 3: Resto
        public Dictionary<int, FlashCardInfo> RestoHostStand { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> RestoForHere { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> RestoFood { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> RestoSentences { get; set; } = new Dictionary<int, FlashCardInfo>();

        public Dictionary<int, Dictionary<int, FlashCardInfo>> RestoContent
        {
            get
            {

                Dictionary<int, Dictionary<int, FlashCardInfo>> RestoContent = new Dictionary<int, Dictionary<int, FlashCardInfo>>(){
                    {1, RestoHostStand },
                    {2, RestoForHere },
                    {3, RestoFood },
                    {4, RestoSentences }
                };
                return RestoContent;
            }
        }

        //Unit 4: Interests
        public Dictionary<int, FlashCardInfo> InterestsBase { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> InterestsPostive { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> InterestsNegative { get; set; } = new Dictionary<int, FlashCardInfo>();
        public Dictionary<int, FlashCardInfo> InterestsSentences { get; set; } = new Dictionary<int, FlashCardInfo>();

        public Dictionary<int, Dictionary<int, FlashCardInfo>> InterestsContent
        {
            get
            {

                Dictionary<int, Dictionary<int, FlashCardInfo>> InterestsContent = new Dictionary<int, Dictionary<int, FlashCardInfo>>(){
                    {1, RestoHostStand },
                    {2, RestoForHere },
                    {3, RestoFood },
                    {4, RestoSentences }
                };
                return InterestsContent;
            }
        }


        //constructors
        public Content() { }

        public Content(bool isIntroGreetingsDone, bool isIntroMoodDone,
            bool isIntroNamesDone, bool isIntroSentencesDone,
            bool isPlansBaseDone, bool isPlansPlacesDone,
            bool isPlansFrequencyDone, bool isPlansSentencesDone,
            bool isRestoHostStandDone, bool isRestoForHereDone,
            bool isRestoFoodDone, bool isRestoSentencesDone,
            bool isInterestsBaseDone, bool isInterestsPositiveDone,
            bool isInterestsNegativeDone, bool isInterestsSentencesDone)

        {
            //todo: when logging in is implemented, add get for saved info
            IsIntroGreetingsDone = isIntroGreetingsDone = false;
            IsIntroMoodDone = isIntroMoodDone = false;
            IsIntroNamesDone = isIntroNamesDone = false;
            IsIntroSentencesDone = isIntroSentencesDone = false;
            IsPlansBaseDone = isPlansBaseDone = false;
            IsPlansPlacesDone = isPlansPlacesDone = false;
            IsPlansFrequencyDone = isPlansFrequencyDone = false;
            IsPlansSentencesDone = isPlansSentencesDone = false;
            IsRestoHostStandDone = isRestoHostStandDone = false;
            IsRestoForHereDone = isRestoForHereDone = false;
            IsRestoFoodDone = isRestoFoodDone = false;
            IsRestoSentencesDone = isRestoSentencesDone = false;
            IsInterestsBaseDone = isInterestsBaseDone = false;
            IsInterestsPositiveDone = isInterestsPositiveDone = false;
            IsInterestsNegativeDone = isInterestsNegativeDone = false;
            IsInterestsSentencesDone = isInterestsSentencesDone = false;
        }
    }
}
