using Module.CMS.Entities;

namespace Module.CMS.Data
{
    public class FaqCreateRequest
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsActive { get; set; }

        public Faq Map(Faq faq = null)
        {
            var entity = faq ?? new Faq();
            entity.Question = Question;
            entity.Answer = Answer;
            entity.IsActive = IsActive;
            
            return entity;
        }
    }
}
