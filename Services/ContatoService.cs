using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Dto.Contato;
using MeuSiteEmMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteEmMVC.Services
{
    public class ContatoService : IContatoInterface
    {
        //injeção de dependência do DbContext para manipular o banco de dados
        private readonly AppDbContext _context;

        public ContatoService(AppDbContext context)
        {
            _context = context;
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

                _context.Add(contato);
                _context.SaveChanges();
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
                    var contatoEditar = await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);
                    return contatoEditar;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar contato", ex);
            }
        }

        public async Task<ContatoModel> ExcluirContato(int? id)
        {
            try
            {
                var contatoExcluir = await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);
                if (id != null)
                {
                    //Remore o contato 
                    _context.Contatos.Remove(contatoExcluir);
                    await _context.SaveChangesAsync();
                }
                return contatoExcluir;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir contato", ex);
            }
        }
    }
}
