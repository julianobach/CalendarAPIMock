using CalendarModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarDataBase
{
    public class OpportunityData
    {
        
        public List<Opportunity> GetAllOpportunitys()
        {
            List<Opportunity> persons = mockGetAllOpportunitys().AsEnumerable().ToList();
            return persons;
        }

        public Opportunity GetOpportunityById(int id)
        {
            Opportunity Opportunity = mockGetOpportunityById(id);
            return Opportunity;
        }

        public string UpdateOpportunity(Opportunity Opportunity)
        {
            try
            {

                mockUpdateOpportunity(Opportunity);

                return "Ok";

            }
            catch (Exception ex)
            {

                return ex.Message;

            }
        }

        public Opportunity InsertOpportunity(Opportunity Opportunity)
        {
            Opportunity ret = mockInsertOpportunity(Opportunity);
            Opportunity.OpportunityId = ret.OpportunityId;
            return Opportunity;
        }

        public string DeleteOpportunity(Opportunity Opportunity)
        {
            try
            {

                return mockDeletOpportunity();

            }
            catch (Exception ex)
            {

                return ex.Message;

            }
        }


        #region Mock
        private List<Opportunity> mockGetAllOpportunitys()
        {
            List<Opportunity> Opportunitys = new List<Opportunity>();

            Opportunitys.Add(new Opportunity()
            {
                OpportunityId = 1,
                CreatedByUserId = 1,
                Active = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                Description = ".Net Developer System - C#, API Rest, Entity FrameWork, Docker, Containners, SQL Server, MongoDB",
                Name = ".Net Developer PL",
                Validate = DateTime.Now.AddMonths(3)
            }
            );

            Opportunitys.Add(new Opportunity()
            {
                OpportunityId = 2,
                CreatedByUserId = 1,
                Active = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                Description = ".Net Developer System - C#, API Rest, Entity FrameWork, Docker, Containners, SQL Server, MongoDB",
                Name = ".Net Developer SR",
                Validate = DateTime.Now.AddMonths(3)
            }
            );

            Opportunitys.Add(new Opportunity()
            {
                OpportunityId = 3,
                CreatedByUserId = 1,
                Active = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                Description = ".Net Developer System - C#, API Rest, Entity FrameWork, Docker, Containners, SQL Server, MongoDB",
                Name = ".Net Developer JR",
                Validate = DateTime.Now.AddMonths(3)
            }
            );

            return Opportunitys;
        }

        private Opportunity mockGetOpportunityById(int id)
        {
            return mockGetAllOpportunitys().Where(p => p.OpportunityId == id).FirstOrDefault();
        }

        private string mockUpdateOpportunity(Opportunity Opportunity) => "OK";

        private Opportunity mockInsertOpportunity(Opportunity Opportunity)
        {
            List<Opportunity> persons = new List<Opportunity>();

            var allOpportunity = mockGetAllOpportunitys();
            int maxSlotId = allOpportunity.Max(p => p.OpportunityId);
            Opportunity.OpportunityId = maxSlotId + 1;


            return Opportunity;
        }

        private string mockDeletOpportunity() => "OK";
        #endregion
    }
}
