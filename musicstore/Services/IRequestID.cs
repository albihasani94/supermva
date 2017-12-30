using System.Threading;

namespace musicstore.Services
{
    public interface IRequestId
    {
        string Id { get; }
    }

    // SCOPED TO A REQUEST CONTEXT
    public class RequestId : IRequestId
    {
        private readonly string _requestId;

        public RequestId(IRequestIdFactory requestIdFactory)
        {
            _requestId = requestIdFactory.MakeRequestId();
        }

        public string Id => _requestId;
    }

    public interface IRequestIdFactory
    {
        string MakeRequestId();
    }

    // SINGLETON
    public class RequestIdFactory : IRequestIdFactory
    {
        private int _requestId;

        public string MakeRequestId()
        {
            return Interlocked.Increment(ref _requestId).ToString();
        }
    }
}