using Case16885.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Case16885.Host
{
    public class CaseMessageHandler : IHandleMessages<CaseMessage>
    {
        private readonly ILog _log = LogManager.GetLogger<CaseMessageHandler>();

        public void Handle(CaseMessage message)
        {
            _log.InfoFormat("Message with Id {0} handled", message.Id);
        }
    }
}
