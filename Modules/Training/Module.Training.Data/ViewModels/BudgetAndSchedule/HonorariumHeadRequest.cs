using Module.Training.Entities;

namespace Module.Training.Data
{
    public class HonorariumHeadRequest
    {
        public long? Id { get; set; }
        public long? Designation { get; set; }
        public string Head { get; set; }
        public double Amount { get; set; }

        public HonorariumHead Map(HonorariumHead honorariumHead = null)
        {
            var entity = honorariumHead ?? new HonorariumHead();
            entity.DesignationId = Designation;
            entity.Head = Head;
            entity.Amount = Amount;
            return entity;
        }
    }
}
