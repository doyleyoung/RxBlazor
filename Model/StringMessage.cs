using System;
using static System.Reactive.Linq.Observable;

static class ExtMethods {
  public static IObservable<string> AsStringMessage(this ActionMessage me) => 
    me is StringMessage sm ? Return(sm.Message) : Empty<string>();
}

public class StringMessage : ActionMessage {
  public readonly string Message;

  public StringMessage(string msg) => Message = msg;
}