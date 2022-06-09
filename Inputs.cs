using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Speech.Synthesis;

public class Input
{
    //actions for each hotkey
    public void UpArrowInput(List<string> patternList)
    {
        patternList.Add("Up");
    }
    public void LeftArrowInput(List<string> patternList)
    {
        patternList.Add("Left");
    }
    public void RightArrowInput(List<string> patternList)
    {
        patternList.Add("Right");
    }

    //Pattern playback + delete previous pattern when complete
    public void PatternPlayback(List<string> patternList)
    {
        //initialize speech synthesis
        SpeechSynthesizer patternPlayback = new SpeechSynthesizer();

        patternPlayback.Volume = 25;
        foreach (var direction in patternList)
        {
            Console.WriteLine(direction);
            patternPlayback.Speak(direction);
        }

        patternList.Clear();
    }
}
