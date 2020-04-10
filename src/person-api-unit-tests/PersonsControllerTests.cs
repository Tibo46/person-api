using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using person_api.Controllers;
using person_api.Database;
using person_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace person_api_unit_tests
{
    public class PersonsControllerTests
    {
        private readonly List<Person> _allPersons;
        private readonly List<Group> _allGroups;

        public PersonsControllerTests()
        {
            _allPersons = GenerateMockPersons();
            _allGroups = GenerateMockGroups();
        }

        [Fact]
        public async void Get_Returns_NotFound_If_NoData()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "db_empty")
                .Options;

            using (var context = new PeopleContext(options))
            {
                var sut = new PersonsController(context);

                var result = await sut.Get("wrong-id");

                Assert.IsType<NotFoundResult>(result.Result);
                Assert.Null(result.Value);
            }
        }

        [Fact]
        public async void Get_Returns_Person_If_Found()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "db_with_data_1")
                .Options;

            using (var context = new PeopleContext(options))
            {
                context.Persons.AddRange(_allPersons);
                context.Groups.AddRange(_allGroups);
                context.SaveChanges();
            }

            using (var context = new PeopleContext(options))
            {
                var sut = new PersonsController(context);

                var actionResult = await sut.Get("person-1");
                Assert.IsType<OkObjectResult>(actionResult.Result);

                var result = actionResult.Result as OkObjectResult;
                var personResult = result.Value as Person;
                var expected = _allPersons.FirstOrDefault(x => x.Id == "person-1");

                Assert.Equal(expected.Id, personResult.Id);
                Assert.Equal(expected.Name, personResult.Name);
                Assert.Equal(expected.GroupId, personResult.GroupId);
            }
        }

        [Fact]
        public async void Search_Returns_EmptyList_If_NoData()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "db_empty")
                .Options;

            using (var context = new PeopleContext(options))
            {
                var sut = new PersonsController(context);

                var actionResult = await sut.Search(null);
                Assert.IsType<OkObjectResult>(actionResult.Result);

                var result = actionResult.Result as OkObjectResult;
                var personsResult = result.Value as List<Person>;

                Assert.Empty(personsResult);
            }
        }

        [Fact]
        public async void Search_Returns_EmptyList_If_NoResult()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "db_with_data_2")
                .Options;


            using (var context = new PeopleContext(options))
            {
                context.Persons.AddRange(_allPersons);
                context.Groups.AddRange(_allGroups);
                context.SaveChanges();
            }

            using (var context = new PeopleContext(options))
            {
                var sut = new PersonsController(context);

                var actionResult = await sut.Search("This search will return nothing");
                Assert.IsType<OkObjectResult>(actionResult.Result);

                var result = actionResult.Result as OkObjectResult;
                var personsResult = result.Value as List<Person>;

                Assert.Empty(personsResult);
            }
        }

        [Fact]
        public async void Search_Returns_Persons_If_PersonName_Match()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "db_with_data_3")
                .Options;


            using (var context = new PeopleContext(options))
            {
                context.Persons.AddRange(_allPersons);
                context.Groups.AddRange(_allGroups);
                context.SaveChanges();
            }

            using (var context = new PeopleContext(options))
            {
                var sut = new PersonsController(context);

                var actionResult = await sut.Search("John");
                Assert.IsType<OkObjectResult>(actionResult.Result);

                var result = actionResult.Result as OkObjectResult;
                var personsResult = result.Value as List<Person>;

                Assert.Equal(2, personsResult.Count);
                Assert.Contains("John", personsResult[0].Name);
                Assert.Contains("John", personsResult[1].Name);
            }
        }

        [Fact]
        public async void Search_Returns_Persons_If_GroupName_Match()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "db_with_data_4")
                .Options;


            using (var context = new PeopleContext(options))
            {
                context.Persons.AddRange(_allPersons);
                context.Groups.AddRange(_allGroups);
                context.SaveChanges();
            }

            using (var context = new PeopleContext(options))
            {
                var sut = new PersonsController(context);

                var actionResult = await sut.Search("Group 3");
                Assert.IsType<OkObjectResult>(actionResult.Result);

                var result = actionResult.Result as OkObjectResult;
                var personsResult = result.Value as List<Person>;

                Assert.Single(personsResult);
                Assert.Contains("Group 3", personsResult[0].Group.Name);
            }
        }

        [Fact]
        public async void Post_Returns_Added_Person()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "db_with_data_5")
                .Options;

            using (var context = new PeopleContext(options))
            {
                context.Persons.AddRange(_allPersons);
                context.Groups.AddRange(_allGroups);
                context.SaveChanges();
            }

            using (var context = new PeopleContext(options))
            {
                var sut = new PersonsController(context);

                var actionResult = await sut.Post(new Person
                {
                    Name = "Walter White",
                    GroupId = 1,
                });
                Assert.IsType<OkObjectResult>(actionResult.Result);

                var result = actionResult.Result as OkObjectResult;
                var personResult = result.Value as Person;

                Assert.Equal("Walter White", personResult.Name);
                Assert.Equal(1, personResult.GroupId);

                var newlyAddedPersonActionResult = await sut.Get(personResult.Id);
                var newlyAddedPersonResult = newlyAddedPersonActionResult.Result as OkObjectResult;
                var newlyAddedPerson = newlyAddedPersonResult.Value as Person;

                Assert.Equal(newlyAddedPerson.Id, personResult.Id);
                Assert.Equal(newlyAddedPerson.Name, personResult.Name);
                Assert.Equal(newlyAddedPerson.GroupId, personResult.GroupId);
            }
        }

        [Fact]
        public async void Post_Returns_500_IfDuplicated()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "db_with_data_6")
                .Options;

            using (var context = new PeopleContext(options))
            {
                context.Persons.AddRange(_allPersons);
                context.Groups.AddRange(_allGroups);
                context.SaveChanges();
            }

            using (var context = new PeopleContext(options))
            {
                var sut = new PersonsController(context);

                var actionResult = await sut.Post(new Person
                {
                    Id = "person-1",
                    Name = "John Doe 1",
                });
                Assert.IsType<StatusCodeResult>(actionResult.Result);

                var result = actionResult.Result as StatusCodeResult;

                Assert.Equal(500, result.StatusCode);
            }
        }

        private List<Group> GenerateMockGroups()
        {
            return new List<Group>
            {
                new Group
                {
                    Id = 1,
                    Name = "Group 1"
                },
                new Group
                {
                    Id = 2,
                    Name = "Group 2"
                },
                new Group
                {
                    Id = 3,
                    Name = "Group 3"
                }
            };
        }

        private List<Person> GenerateMockPersons()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = "person-1",
                    Name = "John Doe 1",
                    GroupId = 1
                },
                new Person
                {
                    Id = "person-2",
                    Name = "John Doe 2",
                    GroupId = 1
                },
                new Person
                {
                    Id = "person-3",
                    Name = "Jane Doe",
                    GroupId = 2
                },
                new Person
                {
                    Id = "person-5",
                    Name = "Joane Deo",
                    GroupId = 3
                }
            };
        }
    }
}
