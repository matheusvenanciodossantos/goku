using FFImageLoading.Maui;
namespace Goku
{
    public delegate void CallBack();

    public class Jogador : Animation
    {
        public Jogador(CachedImageView a) : base(a)
        {
            for (int numero = 1; numero <= 4; numero++)
                Animacao1.Add($"goku{numero:D2}.png");

            for (int numero2 = 1; numero2 <= 2; numero2++)
                Animacao2.Add($"morto{numero2:D2}.png");

            SetAnimationActive(1);
        }

        public void Morto()
        {
            Loop = false;
            SetAnimationActive(2);
        }

        public void Run()
        {
            Loop = true;
            SetAnimationActive(1);
            StartGame();
        }
          public void MoveY(int y)
        {
            compImage.TranslationY += y;
        }

        public double GetY()
        {
            return compImage.TranslationY;
        }

        public void SetY(double a)
        {
            compImage.TranslationY = a;
        }

    }
}