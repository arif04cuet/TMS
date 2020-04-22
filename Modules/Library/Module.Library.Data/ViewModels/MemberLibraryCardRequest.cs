using Module.Library.Entities;
using System;

namespace Module.Library.Data
{
    public class MemberLibraryCardRequest
    {
        public string Number { get; set; }
        public long Card { get; set; }
        public long Status { get; set; }
        public DateTime ExpireDate { get; set; }

        public MemberLibraryCard ToMemberLibraryCard(long userId)
        {
            return new MemberLibraryCard
            {
                CardExpireDate = ExpireDate,
                CardNumber = Number,
                CardStatusId = Status,
                LibraryCardId = Card,
                UserId = userId
            };
        }

        public void MapTo(MemberLibraryCard card)
        {
            if(card != null)
            {
                card.CardExpireDate = ExpireDate;
                card.CardNumber = Number;
                card.CardStatusId = Status;
                card.LibraryCardId = Card;
            }
        }
    }
}
