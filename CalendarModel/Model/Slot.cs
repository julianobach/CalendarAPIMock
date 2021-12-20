using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarModel.Model
{
    public class Slot
    {
        public int SlotID { get; set; }
        public int PersonId { get; set; }
        public int OpportunityId { get; set; } = 0;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool Avaliable { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public bool Active { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public int CreatedByUserId { get; set; }
        public int ModifiedByUserId { get; set; }
        public string StardDayOfWeek()
        {
            return this.StartDateTime.DayOfWeek.ToString();
            
        }
        public string EndDayOfWeek()
        {
            return this.EndDateTime.DayOfWeek.ToString();

        }

        public MessageValidate IsValidSlot()
        {
            MessageValidate messageValidate = new MessageValidate();
            messageValidate.IsValid = true;
            if (this.StartDateTime < DateTime.Now || this.EndDateTime < DateTime.Now || this.StartDateTime > this.EndDateTime
                || StartDateTime.Minute != 0 || StartDateTime.Second != 0 || EndDateTime.Minute != 0 || EndDateTime.Second != 0)
            {
                messageValidate.IsValid = false;
                messageValidate.Message += $"{messageValidate.Message}Invalid Period;";
            }

            if (this.PersonId <= 0)
            {
                messageValidate.IsValid = false;
                messageValidate.Message += $"{messageValidate.Message}Invalid Person;";
            }

            if (this.SlotID < 0)
            {
                messageValidate.IsValid = false;
                messageValidate.Message += $"{messageValidate.Message}Invalid Slot;";
            }

            return messageValidate;
        }

    }


}
