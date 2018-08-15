namespace SA.Application
{
    public class ResponseMessage<T>
    {
        public virtual string Code { get; set; }
        public virtual MessageStatusEnum Status { get; set; }
        public virtual T Entity { get; set; }
    }
}
