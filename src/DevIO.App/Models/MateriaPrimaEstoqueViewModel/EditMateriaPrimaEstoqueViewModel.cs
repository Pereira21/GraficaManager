using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.Models.MateriaPrimaEstoqueViewModel
{
    public class EditMateriaPrimaEstoqueViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Obrigatório!")]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Obrigatório!")]
        public int Quantidade { get; set; }

        public string Imagem { get; set; }
    }
}
