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
    public class GroupsControllerTests
    {
        private readonly List<Group> _allGroups;

        public GroupsControllerTests()
        {
            _allGroups = GenerateMockGroups();
        }

        [Fact]
        public async void Get_Returns_EmptyList_If_NoData()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "db_empty")
                .Options;

            using (var context = new PeopleContext(options))
            {
                var sut = new GroupsController(context);

                var actionResult = await sut.Get();
                Assert.IsType<OkObjectResult>(actionResult.Result);

                var result = actionResult.Result as OkObjectResult;
                var groupsResult = result.Value as List<Group>;

                Assert.Empty(groupsResult);
            }
        }

        [Fact]
        public async void Search_Returns_Persons_If_PersonName_Match()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "db_with_data")
                .Options;


            using (var context = new PeopleContext(options))
            {
                context.Groups.AddRange(_allGroups);
                context.SaveChanges();
            }

            using (var context = new PeopleContext(options))
            {
                var sut = new GroupsController(context);

                var actionResult = await sut.Get();
                Assert.IsType<OkObjectResult>(actionResult.Result);

                var result = actionResult.Result as OkObjectResult;
                var groupsResult = result.Value as List<Group>;

                Assert.Equal(3, groupsResult.Count);
                Assert.Equal("Group 1", groupsResult[0].Name);
                Assert.Contains("Group 2", groupsResult[1].Name);
                Assert.Contains("Group 3", groupsResult[2].Name);
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
    }
}
