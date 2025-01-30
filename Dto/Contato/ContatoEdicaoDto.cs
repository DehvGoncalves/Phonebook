using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Dto.Contato
{
    public class ContatoEdicaoDto
    {
        private readonly IMapper _mapper;
        public ContatoEdicaoDto(IMapper mapper)
        {
            _mapper = mapper;
        }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }
    }
}
