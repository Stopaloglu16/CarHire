using Domain.Common;

namespace Domain.Entities.CardDetailAggregate.EndPoints
{
    public class CardDetailsResponse
    {
        public CardDetailsResponse()
        {
            systemErrorhandler = new BasicErrorHandler();
        }

        public BasicErrorHandler systemErrorhandler { get; set; }

    }
}
