namespace ConsultorioCore.Domain
{
    public class Telefone
    {
        //aqui utilizo o conceito de chave composta com ClienteId + Numero
        public int ClienteId { get; set; }
        public string Numero { get; set; }
        public Cliente Cliente { get; set;}
    }
}