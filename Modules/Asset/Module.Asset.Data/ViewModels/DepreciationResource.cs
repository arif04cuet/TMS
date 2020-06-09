using Module.Asset.Entities;

namespace Module.Asset.Data
{
    public class DepreciationResource
    {
        public string Name { get; set; }
        public int Term { get; set; }
        public int Frequency { get; set; }
        public bool IsActive { get; set; }

        public Depreciation Map(Depreciation depreciation = null)
        {
            var entity = depreciation ?? new Depreciation();
            entity.Name = Name;
            entity.Term = Term;
            entity.Frequency = Frequency;
            entity.IsActive = IsActive;
            return entity;
        }

    }
}