using OpenSleigh.Transport;

namespace OpenSleighGeneral.Saga
{
    public record StartSaga() : IMessage { }

    public record ProcessMySaga() : IMessage { }

    public record MySagaCompleted() : IMessage { }
}
