using System;
using System.Speech.Synthesis;
using System.Collections.Generic;

public class Playback
{
        public static void PatternPlayback(List<string> patternList)
        {
            //initialize speech synthesis
            SpeechSynthesizer patternPlayback = new SpeechSynthesizer();
            patternPlayback.Volume = 25;

            foreach (var direction in patternList)
            {
                Console.WriteLine(direction);
                patternPlayback.Speak(direction);
            }
        }
    }
