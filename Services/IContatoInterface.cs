﻿using MeuSiteEmMVC.Dto.Contato;
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Services
{
    public interface IContatoInterface
    {
        Task<ContatoModel> CriarContato(ContatoCriacaoDto contatoCriacaoDto);
        Task<ContatoModel> BuscarContatoPorId(int? Id);
        Task<ContatoModel> ExcluirContato(int? id);
    }

}
