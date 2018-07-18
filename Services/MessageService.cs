using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using static System.Reactive.Observer;

public class MessageService : IMessageService {
  private readonly Subject<ActionMessage> _subject = new Subject<ActionMessage>();

  public void SendMessage(ActionMessage message) {
    _subject.OnNext(message);
  }

  public IObservable<ActionMessage> MessageStream() {
    return _subject.AsObservable();
  }

  public IDisposable Subscribe(Action<ActionMessage> onNext) {
    return MessageStream().Subscribe(Create(onNext));
  }
}