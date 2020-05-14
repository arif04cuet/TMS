using Module.Asset.Entities;
using System;

namespace Module.Asset.Data
{
    public class AssetAuditCreateRequest
    {
        public long AssetId { get; set; }
        public DateTime AuditDate { get; set; }
        public DateTime NextAuditDate { get; set; }
        public string Note { get; set; }

        public AssetAudit ToMap(AssetAudit entity = null)
        {
            var _entity = entity ?? new AssetAudit();
            _entity.AssetId = AssetId;
            _entity.AuditDate = AuditDate;
            _entity.NextAuditDate = NextAuditDate;
            _entity.Note = Note;
            return _entity;
        }
    }
}
