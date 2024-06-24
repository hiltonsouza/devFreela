using DevFreela.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        // DTO é um acesso a transferencia de dados
        // viewmodel é o objeto que vai sair.
        Task<List<SkillDTO>> GetAll();
    }
}
