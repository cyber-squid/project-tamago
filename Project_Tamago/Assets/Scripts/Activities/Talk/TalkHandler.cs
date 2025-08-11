using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TalkHandler
{
    public Dictionary<string, Dialogue> dialogueDict; // = new Dictionary<string, Dialogue>();


    /*
     * queryhandler 
     */







}

public class Dialogue
{
    string[] linesToSay;
    

    public virtual void OnSaid() { }

}

public class Query
{
    List<string> criteria;
}