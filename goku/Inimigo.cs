using FFImageLoading.Maui;
namespace Goku;

public class Inimigo
{
    image imageView;
    public Inimigo (image a)
    {
        imageView = a;
    }
    public void MoveX(double s)
    {
        imageView.TranslationX-=s;
    }
    public double GetX()
    {
        return imageView.TranslationX;
    }
    public void Reset()
    {
        imageView.TranslationX=500;
    }
}