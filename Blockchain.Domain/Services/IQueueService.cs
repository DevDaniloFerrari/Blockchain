using Blockchain.Engine;

namespace Blockchain.Domain.Services
{
    public interface IQueueService
    {
        public void SendToAwaitingProcessingQueue(Data data);
    }
}
