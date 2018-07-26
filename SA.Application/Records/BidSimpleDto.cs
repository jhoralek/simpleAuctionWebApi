namespace SA.Application.Records
{
    public class BidSimpleDto
    {
        public virtual decimal Price { get; set; }        
        public virtual int RecordId { get; set; }        
        public virtual int UserId { get; set; }
    }
}
