using Application.Contacts;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Moq;
using System.Security.Principal;
using Xunit;

namespace Application.Tests
{
    public class ContactServiceTests 
    {
        private readonly ContactService _contactService;

        public ContactServiceTests()
        {
            var mock = new Mock<IContactRepository>(MockBehavior.Strict);
            mock.Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(new List<Contact> {
                    new Contact { Id=1, Name= "John", Birthday = new DateTime(1990, 3, 10)},
                    new Contact { Id=2, Name= "Sarah", Birthday =new DateTime(1985, 3, 10)},
                    new Contact { Id=3, Name= "Mike", Birthday = new DateTime(1995, 12, 31) }
                });
            _contactService = new ContactService(mock.Object, null);
        }

        [Fact]
        public async Task GetTodayBirthdaysAsync_ReturnsCorrectBirthdays()
        {
            //Arrange
            var expected = 2;

            //Act
            var contacts = await _contactService.GetTodayBirthdaysAsync();

            //Assert
            Assert.Equal(expected, contacts.Count);
        }

        //[Fact]
        //public async Task SendMessageToContactAsync_ShouldBeTrue_IfContactIsNotNull()
        //{
        //    //Arrange
        //    var contact = new Contact { Id = 1, Name = "John", Birthday = new DateTime(1990, 3, 10) };

        //    //Act
        //    var result = await _contactService.SendMessageToContactAsync(contact);

        //    //Assert
        //    result.Should().BeTrue(); 
        //}
    }
}