using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarModel.Model
{
    /// <summary>
    ///  Manage candidates requested slots for the interview
    /// </summary>
    public class CandidateRequestSlots
    {
        public int ResquestSlotId { get; set; }    
        public int SlotId { get; set; }
        public int PersonId { get; set; }
        public int OpportunityId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public int CreatedByUserId { get; set; }
        public int ModifiedByUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
