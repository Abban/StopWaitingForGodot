namespace ClumsyCraig.Payload
{
    public interface IPayload : IResettable
    {
        public void Start();
        public void Stop();
    }
}