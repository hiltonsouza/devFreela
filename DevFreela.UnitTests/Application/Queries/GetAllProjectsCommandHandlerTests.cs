﻿using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            //padrão AAA

            //arrange
            var projects = new List<Project>
            {
                new Project("Nome de Teste", "Descricao de Teste", 1, 2, 10000),
                new Project("Nome de Teste", "Descricao de Teste", 2, 2, 20000),
                new Project("Nome de Teste", "Descricao de Teste", 3, 2, 30000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);
            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);

        }
    }
}
