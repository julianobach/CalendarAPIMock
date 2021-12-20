using CalendarModel;
using CalendarModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarDataBase
{
    public class PersonData
    {
        public List<Person> GetAllPersons()
        {
            List<Person> slots = mockGetAllPersons().AsEnumerable().ToList();
            return slots;
        }
        
        public Person GetPersonById(int id)
        {
            Person person = mockGetPersonById(id);
            return person;
        }        

        public string UpdatePerson(Person person)
        {
            try
            {

                mockUpdatePerson(person);

                return "Ok";

            }
            catch (Exception ex)
            {

                return ex.Message;

            }
        }

        public Person InsertPerson(Person person)
        {
            Person ret = mockInsertPerson(person);
            person.PersonId = ret.PersonId;
            return person;
        }

        public string DeletePerson(Person person)
        {
            try
            {

                return mockDeletPerson();

            }
            catch (Exception ex)
            {

                return ex.Message;

            }
        }
      

        #region Mock
        private List<Person> mockGetAllPersons()
        {
            List<Person> persons = new List<Person>();

            persons.Add(new Person()
            {
                PersonId = 1, //John
                CreatedByUserId = 1,
                Active = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                Email = "john@test.com",
                Name = "Jhon Test",
                PersonType = PersonTypeEnum.Candidate,
            }
            );

            persons.Add(new Person()
            {
                PersonId = 2, //John
                CreatedByUserId = 1,
                Active = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                Email = "mary@test.com",
                Name = "Mary Test",
                PersonType = PersonTypeEnum.Request,
            }
            );

            persons.Add(new Person()
            {
                PersonId = 3, //Diana
                CreatedByUserId = 1,
                Active = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = DateTime.Now,
                ModifiedByUserId = 1,
                Email = "diana@test.com",
                Name = "Diana Test",
                PersonType = PersonTypeEnum.Request,
            }
            );

            return persons;
        }

        private Person mockGetPersonById(int id)
        {
            return mockGetAllPersons().Where(p => p.PersonId == id).FirstOrDefault();
        }

        private string mockUpdatePerson(Person person) => "OK";

        private Person mockInsertPerson(Person person)
        {
            List<Person> slots = new List<Person>();

            var allPerson = mockGetAllPersons();
            int maxSlotId = allPerson.Max(p => p.PersonId);
            person.PersonId = maxSlotId + 1;


            return person;
        }

        private string mockDeletPerson() => "OK";
        #endregion
    }
}
