using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace MemoryGameCheater
{
    public class Program
    {
        static void Main(string[] args)
        {
            //initialize list to hold pattern
            var patternList = new List<string>();

            Console.WriteLine("Press arrow keys");

            //assign hotkeys to actions
            var upArrowAssign = Combination.FromString("Up");
            var leftArrowAssign = Combination.FromString("Left");
            var rightArrowAssign = Combination.FromString("Right");
            var playbackAssign = Combination.FromString("PageDown");

            var assignment = new Dictionary<Combination, Action>
            {
                {upArrowAssign, () => patternList.Add("Up")},
                {leftArrowAssign, () => patternList.Add("Left")},
                {rightArrowAssign, () => patternList.Add("Right")},
                {playbackAssign, () =>
                {
                    Playback.PatternPlayback(patternList);
                    patternList.Clear();
                }}
            };

            Hook.GlobalEvents().OnCombination(assignment);

            Application.Run(new ApplicationContext());

            
        }
    }
}