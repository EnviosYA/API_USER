using PS.Template.AccessData.Commands;
using PS.Template.AccessData.cualquiera;
using PS.Template.Domain;
using PS.Template.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.AccessData.Repositories
{
    public class UsuarioRepository : GenericsRepository<Usuario> , IUsuarioRepository
    {
        public UsuarioRepository(UsuarioDBContext context) : base(context)
        {

        }

    }
}
