using Application.Contacts;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using Xunit;

namespace Application.Tests
{
    public class ContactServiceTests 
    {
        [Fact]
        public async Task GetTodayBirthdays_ReturnsCorrectBirthdays()
        {
            //Arrange
            var mock = new Mock<IContactRepository>(MockBehavior.Strict);
            mock.Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(new List<Contact> { 
                    new Contact { Id=1, Name= "John", Birthday = new DateTime(1990, 3, 10)}, 
                    new Contact { Id=2, Name= "Sarah", Birthday =new DateTime(1985, 3, 10)}, 
                    new Contact { Id=3, Name= "Mike", Birthday = new DateTime(1995, 12, 31) } 
                });
            List<Contact> todayBirthdays = new List<Contact>();
            var contactService = new ContactService(mock.Object);

            //Act
            var contacts = await contactService.GetTodayBirthdays();
            
            DateTime today = DateTime.Today;
            foreach (var contact in contacts)
            {
                if (contact.Birthday.Day == today.Day && contact.Birthday.Month == today.Month)
                {
                    todayBirthdays.Add(contact);
                }
            }

            //Assert
            Assert.Equal(2, todayBirthdays.Count);
        }
    }
}