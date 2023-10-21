namespace EstacionamentoAPI.Repositories
{
    
        public interface ICarroRepository
        {
            IEnumerable<Carro> ObterTodosCarros();
            Carro ObterCarroPorPlaca(string placa);
            void AdicionarCarro(Carro carro);
            void AtualizarCarro(Carro carro);
            void DeletarCarro(string placa);
        }
    

}