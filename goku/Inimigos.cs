using FFImageLoading.Maui;

namespace Goku
{
    public class Inimigos
    {
        // Lista para armazenar todos os inimigos
        private List<Inimigo> inimigos = new List<Inimigo>();

        // Referência para o inimigo atual (se houver)
        private Inimigo atual = null;

        // Coordenada mínima X (para posicionamento)
        private double minX;

        // Construtor para inicializar com o valor de minX
        public Inimigos(double a)
        {
            minX = a;
        }

        // Adiciona um inimigo à lista
        public void Add(Inimigo inimigo)
        {
            inimigos.Add(inimigo);
            if (atual == null)
            {
                // Define o primeiro inimigo adicionado como o atual
                atual = inimigo;
            }
            Iniciar(); // Inicializa ou reseta os inimigos
        }

        // Reseta todos os inimigos
        public void Iniciar()
        {
            foreach (var inimigo in inimigos)
            {
                inimigo.Reset(); // Presume-se que o método Reset existe na classe Inimigo
            }
        }
    }
}
