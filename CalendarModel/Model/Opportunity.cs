using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarModel.Model
{
    public class Opportunity
    {
        public int  OpportunityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Validate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool Active { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public int CreatedByUserId { get; set; }
        public int ModifiedByUserId { get; set; }

        public MessageValidate IsValidOpportunity()
        {
            MessageValidate messageValidate = new MessageValidate();
            messageValidate.IsValid = true;

            if (String.IsNullOrEmpty(this.Name))
            {
                messageValidate.IsValid = false;
                messageValidate.Message += $"{messageValidate.Message}Invalid Name;";
            }

            if (String.IsNullOrEmpty(this.Description))
            {
                messageValidate.IsValid = false;
                messageValidate.Message += $"{messageValidate.Message}Invalid Description;";
            }

            if (this.Validate > DateTime.Now)
            {
                messageValidate.IsValid = false;
                messageValidate.Message += $"{messageValidate.Message}Invalid Validate;";
            }

            if (this.OpportunityId < 0)
            {
                messageValidate.IsValid = false;
                messageValidate.Message += $"{messageValidate.Message}Invalid OpportunityId;";
            }

            return messageValidate;
        }
    }
}
