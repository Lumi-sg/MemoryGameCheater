using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace MemoryGameCheater
{
    public class Program
    {
        static void Main(string[] args)
        {
            //initialize list to hold pattern
            var patternList = new List<string>();

            //initialize speech synthesis
            SpeechSynthesizer patternPlayback = new SpeechSynthesizer();
            patternPlayback.Volume = 25;

            Console.WriteLine("Press arrow keys");

            //assign hotkeys to actions
            var upArrowAssign = Combination.FromString("Up");
            var leftArrowAssign = Combination.FromString("Left");
            var rightArrowAssign = Combination.FromString("Right");
            var playbackAssign = Combination.FromString("PageDown");

            var assignment = new Dictionary<Combination, Action>
            {
                {upArrowAssign, UpArrowInput},
                {leftArrowAssign, LeftArrowInput},
                {rightArrowAssign, RightArrowInput},
                {playbackAssign, PatternPlayback}

            };

            Hook.GlobalEvents().OnCombination(assignment);

            Application.Run(new ApplicationContext());


            //actions for each hotkey
              void UpArrowInput()
            {
                patternList.Add("Up");
            }
              void LeftArrowInput()
            {
                patternList.Add("Left");
            }
              void RightArrowInput()
            {
                patternList.Add("Right");
            }

              //Pattern playback + delete previous pattern when complete
              void PatternPlayback()
              {
                  foreach (var direction in patternList)
                  {
                      Console.WriteLine(direction);
                      patternPlayback.Speak(direction);
                  }

                  patternList.Clear();
              }
        }
    }
}
