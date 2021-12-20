using CalendarModel.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net.Http;
using System.Text;

namespace TestCalendarAPI
{
    public class Tests
    {
        private static string urlTest = "https://localhost:44396/api/";
        private static string token = "12345";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetSlotByPerson()
        {
            int personId = 1;
            var client = new RestClient($"{urlTest}Slots/ByPersonId?id={personId}&token={token}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "57461c5b-b43f-1b68-11fe-9917b42ef858");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            Assert.IsTrue(response.StatusCode ==  System.Net.HttpStatusCode.OK);
        }

        [Test]
        public void TestInsertInvaldSlot()
        {
            var client = new RestClient($"{urlTest}Slots?token={token}");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "30734422-1cbb-0c1a-7242-49941b6ae59f");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");

            Slot slot = new Slot();
            slot.PersonId = 2;
            slot.StartDateTime = this.GetNextDate(DayOfWeek.Tuesday, 9);
            slot.EndDateTime = this.GetNextDate(DayOfWeek.Tuesday, 10);

            var slotString = JsonConvert.SerializeObject(slot);

            request.AddParameter("application/json", slotString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Assert.IsFalse(response.StatusCode == System.Net.HttpStatusCode.OK, response.Content);
        }

        public void TestInsertValdSlot()
        {
            var client = new RestClient($"{urlTest}Slots?token={token}");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "30734422-1cbb-0c1a-7242-49941b6ae59f");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");

            Slot slot = new Slot();
            slot.PersonId = 2;
            slot.StartDateTime = this.GetNextDate(DayOfWeek.Tuesday, 10);
            slot.EndDateTime = this.GetNextDate(DayOfWeek.Tuesday, 11);

            var slotString = JsonConvert.SerializeObject(slot);

            request.AddParameter("application/json", slotString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK, response.Content);
        }

        public DateTime GetNextDate(DayOfWeek dayOfWeek, int hour)
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
    }
}