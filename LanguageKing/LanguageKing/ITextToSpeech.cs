using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ITextToSpeech
{
    void Speak(string text, int lang);

    void SetLocale(int lang);
}