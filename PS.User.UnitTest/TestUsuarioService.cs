using Moq;
using NUnit.Framework;
using PS.Template.Application.Services;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.IGenerateRequest;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.User.UnitTest
{
    public class TestUsuarioService
    {
        private Mock<IUsuarioQuery> _query;
        private Mock<IGenerateRequest> _request;
        protected Mock<IUsuarioRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _query = new Mock<IUsuarioQuery>();
            _request = new Mock<IGenerateRequest>();
            _repository = new Mock<IUsuarioRepository>();
        }

        [Test]
        public void DeletearUsuario()
        {
            //Arrange
            int id = 0;
            UsuarioServices usuarioServices = new UsuarioServices(_repository.Object,_query.Object,_request.Object);

            //Act
            var result = usuarioServices.DeletearUsuario(id);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetUsuarios()
        {
            //Arrange
            int id = 0;
            string dni = "";
            UsuarioServices usuarioServices = new UsuarioServices(_repository.Object, _query.Object, _request.Object);

            //Act
            var result = usuarioServices.GetUsuarios(id, dni);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void UpdateUsuario()
        {
            //Arrange
            int id = 0;
            RequestPost user = new RequestPost();
            UsuarioServices usuarioServices = new UsuarioServices(_repository.Object, _query.Object, _request.Object);

            //Act
            var result = usuarioServices.UpDateUsuario(id, user);

            //Assert
            Assert.IsNull(result);
        }

       
    }
}
