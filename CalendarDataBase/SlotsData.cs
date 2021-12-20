using CalendarModel.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CalendarDataBase
{
    public class SlotsData
    {

        public List<Slot> GetSlotsByPersonId(int PersonId)
        {
            List<Slot> slots = mockGetSlotsByPersonID(PersonId).AsEnumerable().ToList();
            return slots;
        }  
        
        public List<Slot> GetAllSlots()
        {
            List<Slot> slots = mockGetAllSlots().AsEnumerable().ToList();
            return slots;

        }

        public Slot GetSlotById(int id)
        {
            Slot slot = mockGetSlotById(id);
            return slot;
        }
        
        public string UpdateSlot(Slot slot)
        {

            try
            {

                mockUpdateSlot(slot);

                return "Ok";

            }
            catch (Exception ex)
            {

                return ex.Message;

            }
        }

        public Slot InsertSlot(Slot slot)
        {
            try
            {
                List<Slot> slots = this.GetSlotsByPersonId(slot.PersonId)
                                    .Where(s => s.Active == true && s.IsDeleted == false && s.EndDateTime >= DateTime.Now)
                                    .AsEnumerable().ToList();

                int tot = slots.Where(s => s.StartDateTime >= slot.StartDateTime && s.EndDateTime <= slot.EndDateTime).Count();

                if (tot > 0)
                    throw new Exception($"Invalid Period. This Period is busy");

                Slot ret = mockInsertSlot(slot);
                slot.SlotID = ret.SlotID;
                return slot;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        public String DeleteSlot(Slot slot)
        {
            try
            {

                return mockDeletSlot();

            }
            catch (Exception ex)
            {

                return ex.Message;

            }
        }

        #region toll
        public static DateTime GetNextDate(DayOfWeek dayOfWeek, int hour)
        {
            try
            {
                DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, 0, 0);

                while (true)
                {
                    if (dateTime.DayOfWeek != dayOfWeek)
                        dateTime = dateTime.AddDays(1);
                    else
                        return dateTime; 
                    
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem to get date. Error: {ex.Message}");
            }
        }

        #endregion

        #region Mock
        public string mockDeletSlot() => "OK";
        public string mockUpdateSlot(Slot slot) => "OK";
        private Slot mockInsertSlot(Slot slot)
        {
            List<Slot> slots = new List<Slot>();

            var allSlots = GetAllSlots();
            int maxSlotId = allSlots.Max(p => p.SlotID);
            slot.SlotID = maxSlotId + 1;
            

            return slot;
        }
        private static List<Slot> mockGetAllSlots()
        {
            List<Slot> slots = new List<Slot>();

            #region Jhon
            slots.Add(new Slot()
            {
                SlotID = 1,
                PersonId = 1, //John
                CreatedByUserId = 1,
                Active = true,
                Avaliable = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                StartDateTime = GetNextDate(DayOfWeek.Tuesday, 9),
                EndDateTime = GetNextDate(DayOfWeek.Tuesday, 10)
            }
            );

            slots.Add(new Slot()
            {
                SlotID = 2,
                PersonId = 1, //John
                CreatedByUserId = 1,
                Active = true,
                Avaliable = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                StartDateTime = GetNextDate(DayOfWeek.Thursday, 9),
                EndDateTime = GetNextDate(DayOfWeek.Thursday, 10)
            }
            );
            #endregion Jhon

            #region Mary
            slots.Add(new Slot()
            {
                SlotID = 3,
                PersonId = 2, //Mary
                CreatedByUserId = 1,
                Active = true,
                Avaliable = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                StartDateTime = GetNextDate(DayOfWeek.Tuesday, 9),
                EndDateTime = GetNextDate(DayOfWeek.Tuesday, 10)
            }
            );

            slots.Add(new Slot()
            {
                SlotID = 4,
                PersonId = 2, //Mary
                CreatedByUserId = 1,
                Active = true,
                Avaliable = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                StartDateTime = GetNextDate(DayOfWeek.Thursday, 9),
                EndDateTime = GetNextDate(DayOfWeek.Thursday, 10)
            }
            );
            #endregion Jhon

            #region Diana
            slots.Add(new Slot()
            {
                SlotID = 5,
                PersonId = 3, //Diana
                CreatedByUserId = 1,
                Active = true,
                Avaliable = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                StartDateTime = GetNextDate(DayOfWeek.Tuesday, 9),
                EndDateTime = GetNextDate(DayOfWeek.Tuesday, 10)
            }
            );

            slots.Add(new Slot()
            {
                SlotID = 6,
                PersonId = 3, //Diana
                CreatedByUserId = 1,
                Active = true,
                Avaliable = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                StartDateTime = GetNextDate(DayOfWeek.Thursday, 9),
                EndDateTime = GetNextDate(DayOfWeek.Thursday, 10)
            }
            );
            #endregion
            return slots;
        }
        private List<Slot> mockGetSlotsByPersonID(int PersonId)
        {
            return GetAllSlots().Where(p => p.PersonId == PersonId).ToList();
        }
        private Slot mockGetSlotById(int id)
        {

            var allSlots = GetAllSlots();
            Slot slot = allSlots.Where(p => p.SlotID == id).AsEnumerable().FirstOrDefault();

            return slot;
        }
        #endregion
    }
}
