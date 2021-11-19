namespace CadastroGastos.Models
{
    public class Contas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string DataPagamento { get; set; }
        public bool Ativo { get; set; }
    }
}
