using System;

public interface IMessageService {
  void SendMessage(ActionMessage message);

  IObservable<ActionMessage> MessageStream();

  IDisposable Subscribe(Action<ActionMessage> onNext);
}