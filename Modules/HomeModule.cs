using Nancy;
using FriendLetter.Objects; //Must match the namespace in LetterVariable.cs

namespace FriendLetter
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        LetterVariables myLetterVariables = new LetterVariables();
        myLetterVariables.SetRecipient("Eric");
        myLetterVariables.SetSender("John");
        myLetterVariables.SetLocation("Hawaii");
        myLetterVariables.SetItem("coconut");
        return View["hello.cshtml", myLetterVariables];
      };
      Get["/form"] = _ => {
        return View["form.cshtml"];
      };
      Get["/greeting_card"] = _ => {
        LetterVariables myLetterVariables = new LetterVariables();
        myLetterVariables.SetRecipient(Request.Query["recipient"]);
        myLetterVariables.SetSender(Request.Query["sender"]);
        myLetterVariables.SetLocation(Request.Query["location"]);
        myLetterVariables.SetItem(Request.Query["item"]);
        return View["hello.cshtml", myLetterVariables];
      };
    }
  }
}
