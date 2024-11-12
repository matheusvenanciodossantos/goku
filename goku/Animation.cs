namespace Goku
{
    public class Animation
    {
        // Listas para armazenar os quadros das animações
        protected List<string> Animacao1 = new List<string>();
        protected List<string> Animacao2 = new List<string>();
        protected List<string> Animacao3 = new List<string>();

        // Flags para controlar o loop da animação e a animação ativa
        protected bool Loop = true;
        protected int AnimacaoAtiva = 1;
        protected Image compImage;

        // Controle de parada da animação
        private bool Parado = true;
        private int QuadroAtual = 1;

        // Construtor que recebe a imagem
        public Animation(Image image)
        {
            compImage = image;
        }

        // Inicia a animação
        public void StartGame()
        {
            Parado = false;
        }

        // Para a animação
        public void Stop()
        {
            Parado = true;
        }

        // Define qual animação será ativa (1, 2 ou 3)
        public void SetAnimationActive(int a)
        {
            AnimacaoAtiva = a;
        }

        // Método para desenhar (atualizar) a animação na tela
        public virtual void Desenha()
        {
            if (Parado)
                return;

            string NomeDoArquivo = "";
            List<string> frames = null;

            // Seleciona qual animação está ativa
            switch (AnimacaoAtiva)
            {
                case 1:
                    frames = Animacao1;
                    break;
                case 2:
                    frames = Animacao2;
                    break;
                case 3:
                    frames = Animacao3;
                    break;
            }

            // Se a animação tiver quadros
            if (frames != null && QuadroAtual < frames.Count)
            {
                NomeDoArquivo = frames[QuadroAtual];
                compImage.Source = ImageSource.FromFile(NomeDoArquivo);
                QuadroAtual++;
            }

            // Verifica se todos os quadros foram exibidos
            if (QuadroAtual >= frames.Count)
            {
                if (Loop)
                {
                    // Se a animação deve fazer loop, reinicia o quadro
                    QuadroAtual = 0;
                }
                else
                {
                    // Se não deve fazer loop, para a animação
                    Parado = true;
                    QuandoParar();
                }
            }
        }

        // Método que será chamado quando a animação parar. Pode ser sobrescrito.
        public virtual void QuandoParar()
        {
            // Comportamento padrão quando a animação parar (pode ser sobrescrito)
        }
    }
}