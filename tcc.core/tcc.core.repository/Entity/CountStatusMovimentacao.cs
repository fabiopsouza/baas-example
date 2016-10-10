namespace tcc.core.repository.Entity
{
    public class CountStatusMovimentacao
    {
        public int Pendentes { get; set; }

        public int Aprovados { get; set; }

        public int Reprovados { get; set; }

        public CountStatusMovimentacao()
        {

        }

        public CountStatusMovimentacao(int pendentes, int aprovados, int reprovados)
        {
            Pendentes = pendentes;
            Aprovados = aprovados;
            Reprovados = reprovados;
        }
    }
}
