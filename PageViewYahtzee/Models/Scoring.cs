using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace PageViewYahtzee.Models
{
    public class Scoring
    {
        private ObservableCollection<int> scores;
        private ObservableCollection<bool> scoreable;
        private int[] diceArray;

        public Scoring(ObservableCollection<int> scores, ObservableCollection<bool> scoreable, int[] diceArray)
        {
            this.scores = scores;
            this.scoreable = scoreable;
            this.diceArray = diceArray;
        }

        public bool Score3Kind()
        {
            var scoreValid = false;
            var totalDice = 0;

            for (var i = 0; i < 5; i++)
            {
                if (scoreValid)
                    break;
                for (var j = i + 1; j < 5; j++)
                {
                    if (scoreValid)
                        break;
                    if (diceArray[i] == diceArray[j])
                    {
                        for (var k = j + 1; k < 5; k++)
                        {
                            if (diceArray[i] == diceArray[k])
                            {
                                for (var l = 0; l < 5; l++)
                                {
                                    totalDice += diceArray[l];
                                }
                                scoreValid = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (scoreValid)
            {
                scores[6] = totalDice;

            }
            else
            {
                scores[6] = 0;
            }
            scores[16] = 0;
            for (var i = 6; i < 13; i++)
            {
                if (scores[i] != -1)
                {
                    scores[16] += scores[i];
                }
            }
            scores[17] = scores[16] + scores[15];
            for (var i = 0; i < 13; i++)
            {
                scoreable[i] = false;
            }
            scoreable[13] = true;
            return scoreValid;
        }

        public bool Score4Kind()
        {
            var scoreValid = false;
            var totalDice = 0;

            for (var i = 0; i < 5; i++)
            {
                if (scoreValid)
                    break;
                for (var j = i + 1; j < 5; j++)
                {
                    if (scoreValid)
                        break;
                    if (diceArray[i] == diceArray[j])
                    {
                        for (var k = j + 1; k < 5; k++)
                        {
                            if (scoreValid)
                                break;
                            if (diceArray[i] == diceArray[k])
                            {
                                for (var m = k + 1; m < 5; m++)
                                {
                                    if (diceArray[i] == diceArray[m])
                                    {
                                        for (var l = 0; l < 5; l++)
                                        {
                                            totalDice += diceArray[l];
                                        }
                                        scoreValid = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (scoreValid)
            {
                scores[7] = totalDice;

            }
            else
            {
                scores[7] = 0;
            }
            scores[16] = 0;
            for (var i = 6; i < 13; i++)
            {
                if (scores[i] != -1)
                {
                    scores[16] += scores[i];
                }
            }
            scores[17] = scores[16] + scores[15];
            for (var i = 0; i < 13; i++)
            {
                scoreable[i] = false;
            }
            scoreable[13] = true;
            return scoreValid;
        }

        public bool ScoreFullHouse()
        {
            var score3Valid = false;
            var score2Valid = false;
            var locationOf3 = -1;

            //Looks for 3 of a kind
            for (var i = 0; i < 3; i++)
            {
                for (var j = i + 1; j < 4; j++)
                {
                    if (diceArray[i] == diceArray[j])
                    {
                        for (var k = j + 1; k < 5; k++)
                        {
                            if (diceArray[i] == diceArray[k])
                            {
                                locationOf3 = i;
                                score3Valid = true;
                            }
                        }
                    }
                }
            }
            //Looks for the remaining pair and checks to make sure they do not equal the other values
            for (var i = 0; i < 4; i++)
            {
                for (var j = i + 1; j < 5; j++)
                {
                    if (diceArray[i] == diceArray[j] && diceArray[i] != locationOf3)
                    {
                        score2Valid = true;
                    }
                }
            }
            if (score2Valid && score3Valid)
            {
                scores[8] = 25;

            }
            else
            {
                scores[8] = 0;
            }
            scores[16] = 0;
            for (var i = 6; i < 13; i++)
            {
                if (scores[i] != -1)
                {
                    scores[16] += scores[i];
                }
            }
            scores[17] = scores[16] + scores[15];
            for (var i = 0; i < 13; i++)
            {
                scoreable[i] = false;
            }
            scoreable[13] = true;
            return score2Valid && score3Valid;
        }

        public bool ScoreSmStraight()
        {
            var scoreValid = false;
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    if (diceArray[i] + 1 == diceArray[j])
                    {
                        for (var k = 0; k < 5; k++)
                        {
                            if (diceArray[j] + 1 == diceArray[k])
                            {
                                for (var l = 0; l < 5; l++)
                                {
                                    if (diceArray[k] + 1 == diceArray[l])
                                        scoreValid = true;

                                }
                            }
                        }
                    }
                }
            }
            if (scoreValid)
            {
                scores[9] = 30;

            }
            else
            {
                scores[9] = 0;
            }
            scores[16] = 0;
            for (var i = 6; i < 13; i++)
            {
                if (scores[i] != -1)
                {
                    scores[16] += scores[i];
                }
            }
            scores[17] = scores[16] + scores[15];
            for (var i = 0; i < 13; i++)
            {
                scoreable[i] = false;
            }
            scoreable[13] = true;
            return scoreValid;
        }

        public bool ScoreLgStraight()
        {
            var scoreValid = false;
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    if (diceArray[i] + 1 == diceArray[j])
                    {
                        for (var k = 0; k < 5; k++)
                        {
                            if (diceArray[j] + 1 == diceArray[k])
                            {
                                for (var l = 0; l < 5; l++)
                                {
                                    if (diceArray[k] + 1 == diceArray[l])
                                    {
                                        for (var m = 0; m < 5; m++)
                                        {
                                            if (diceArray[l] + 1 == diceArray[m])
                                            {
                                                scoreValid = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (scoreValid)
            {
                scores[10] = 40;

            }
            else
            {
                scores[10] = 0;
            }
            scores[16] = 0;
            for (var i = 6; i < 13; i++)
            {
                if (scores[i] != -1)
                {
                    scores[16] += scores[i];
                }
            }
            scores[17] = scores[16] + scores[15];
            for (var i = 0; i < 13; i++)
            {
                scoreable[i] = false;
            }
            scoreable[13] = true;
            return scoreValid;
        }

        public bool ScoreYahtzee()
        {
            var scoreValid = true;
            var num = diceArray[0];
            for (var i = 0; i < 5; i++)
            {
                if (num != diceArray[i])
                {
                    scoreValid = false;
                }
            }
            if (scoreValid)
            {
                scores[11] = 50;
                new SoundPlayer("C:/Users/nschroeder/Documents/Audacity/Ultimate-Yahtzee-Jingle-Final.wav").Play(); // plays audio for yahtzee

            }
            else
            {
                scores[11] = 0;
            }
            scores[16] = 0;
            for (var i = 6; i < 13; i++)
            {
                if (scores[i] != -1)
                {
                    scores[16] += scores[i];
                }
            }
            scores[17] = scores[16] + scores[15];
            for (var i = 0; i < 13; i++)
            {
                scoreable[i] = false;
            }
            scoreable[13] = true;
            return scoreValid;
        }

        public void ScoreChance()
        {
            var sum = 0;
            for (var i = 0; i < 5; i++)
            {
                sum += diceArray[i];
            }
            scores[12] = sum;
            scores[16] = 0;
            for (var i = 6; i < 13; i++)
            {
                if (scores[i] != -1)
                {
                    scores[16] += scores[i];
                }
            }
            scores[17] = scores[16] + scores[15];
            for (var i = 0; i < 13; i++)
            {
                scoreable[i] = false;
            }
            scoreable[13] = true;
        }

        public void ScorePoints(int diceValue)
        {
            var score = 0;
            for (var i = 0; i < 5; i++)
            {
                if (diceArray[i] == diceValue)
                {
                    score++;
                }
            }
            scores[diceValue - 1] = score * diceValue;
            scores[14] = 0;
            for (var i = 0; i < 6; i++)
            {
                if (scores[i] != -1)
                {
                    scores[14] += scores[i];
                }
            }
            if (scores[14] > 62)
                scores[13] = 35;
            scores[15] = scores[13] + scores[14];
            scores[17] = scores[16] + scores[15];
            for (var i = 0; i < 13; i++)
            {
                scoreable[i] = false;
            }
            scoreable[13] = true;
        }
    }
}
