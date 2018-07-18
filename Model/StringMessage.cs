using System;
using System.Reactive.Linq;

static class ExtMethods {
  public static IObservable<string> AsStringMessage(this ActionMessage me) =>
    me is StringMessage sm ? Observable.Return(sm.Message) : Observable.Empty<string>();
}

public class StringMessage : ActionMessage {
  public readonly string Message;

  public StringMessage(string msg) {
    Message = msg;
  }
}