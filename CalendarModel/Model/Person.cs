using CalendarModel.Enum;
using CalendarModel.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace CalendarModel
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }   
        public string Email { get; set; }  
        public PersonTypeEnum PersonType { get; set; }
        public bool IsDeleted { get; set; }
        public bool Active { get; set; }   
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public int CreatedByUserId { get; set; }
        public int ModifiedByUserId { get; set; }

        public MessageValidate IsValidPerson()
        {
            MessageValidate messageValidate = new MessageValidate();
            messageValidate.IsValid = true;

            if (String.IsNullOrEmpty(this.Name))
            {
                messageValidate.IsValid = false;
                messageValidate.Message += $"{messageValidate.Message}Invalid Name;";
            }

            if (String.IsNullOrEmpty(this.Email) && new EmailAddressAttribute().IsValid(this.Email))
            {
                messageValidate.IsValid = false;
                messageValidate.Message += $"{messageValidate.Message}Invalid Email;";
            }

            return messageValidate;
        }
    }
}
