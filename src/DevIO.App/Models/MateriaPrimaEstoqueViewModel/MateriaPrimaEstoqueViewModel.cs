using System;

namespace DevIO.App.Models.MateriaPrimaEstoqueViewModel
{
    public class MateriaPrimaEstoqueViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }
    }
}
