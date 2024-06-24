using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjetcCommand : IRequest<Unit>
    {
        public StartProjetcCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
