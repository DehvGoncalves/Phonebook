using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Dto.Contato;
using MeuSiteEmMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteEmMVC.Services
{
    public class ContatoService : IContatoInterface
    {
        //injeção de dependência do DbContext para manipular o banco de dados
        private readonly AppDbContext _Context;

        public ContatoService(AppDbContext context)
        {
            _Context = context;
        }
        public Task<ContatoModel> CriarContato(ContatoCriacaoDto contatoCriacaoDto)
        {
            try
            {
                var contato = new ContatoModel
                {
                    Nome = contatoCriacaoDto.Nome,
                    Telefone = contatoCriacaoDto.Telefone,
                    Email = contatoCriacaoDto.Email
                };

                _Context.Add(contato);
                _Context.SaveChanges();
                return Task.FromResult(contato);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar contato", ex);
            }
        }

        public async Task<ContatoModel> BuscarContatoPorId(int? id)
        {
            try
            {
                if(id.HasValue)
                {
                    var contatoEditar = await _Context.Contatos.FirstOrDefaultAsync(x => x.Id == id);
                    return contatoEditar;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar contato", ex);
            }
        }
    }
}
