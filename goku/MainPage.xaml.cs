using Goku;

namespace goku;

public partial class MainPage : ContentPage
{

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	private bool IsDead = false;

	private bool IsJumping = false;

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	const int Fps = 25;

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


	private int Speed1 = 0;

	private int Speed2 = 0;

	private int Speed3 = 0;



	private int CharacterSpeed = 0;

	private int WindowWidth = 0;

	private int WindowHeight = 0;

	Jogador jogador;

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	public MainPage()
	{
		InitializeComponent();

		jogador= new Jogador(imgJogador);
		jogador.Run();

	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Drawn();
		//o drawn tá só de teste
	}


	protected override void OnSizeAllocated(double width, double heigth)
	{
		base.OnSizeAllocated(width, heigth);
		CorrectWindowSize(width, heigth);
		SpeedCalculate(width);
			 
	}

	void CorrectWindowSize (double width, double heigth)
	{
		foreach (var LayerOne in HorizontalDaBolaDoDragao.Children)
		(LayerOne as Image).WidthRequest = width;

		foreach (var LayerTwo in HorizontalMontanha.Children)
		(LayerTwo as Image).WidthRequest = width;

		foreach (var LayerThree in HorizontalDoFundo.Children)
		(LayerThree as Image).WidthRequest = width;

		foreach (var LayerThree in HorizontalChao.Children)
		(LayerThree as Image).WidthRequest = width;

	

		foreach (var Floor in HorizontalChao.Children)
		(Floor as Image).WidthRequest = width;

		HorizontalDaBolaDoDragao.WidthRequest = width * 1.0;
		HorizontalMontanha.WidthRequest = width * 1.0;
		HorizontalDoFundo.WidthRequest = width * 1.0;
		HorizontalChao.WidthRequest = width * 1.0;
		


	}

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	private void SpeedCalculate(double width)
	{
		Speed1 = (int) (width * 0.005);
		Speed2 = (int) (width * 0.005);
		Speed3 = (int) (width * 0.005);
		CharacterSpeed = (int) (width * 0.007);
	}

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	private void GerenciaCenarios()
	{
		MoveCenario();
		ManageCenario(HorizontalDaBolaDoDragao);
		ManageCenario(HorizontalMontanha);
		ManageCenario(HorizontalDoFundo);
		ManageCenario(HorizontalChao);
	}

	private void MoveCenario()
	{
		HorizontalDaBolaDoDragao.TranslationX -= Speed1;
		HorizontalMontanha.TranslationX -= Speed2;
		HorizontalDoFundo.TranslationX -= Speed3;
		HorizontalChao.TranslationX -= CharacterSpeed;
	}

	private void ManageCenario(HorizontalStackLayout horizontal)
	{
		var visualizar = (horizontal.Children.First() as Image);
		if (visualizar.WidthRequest + horizontal.TranslationX < 0)
		{
			horizontal.Children.Remove(visualizar);
			horizontal.Children.Add(visualizar);
			horizontal.TranslationX = visualizar.TranslationX;
		}
	}

	async Task Drawn()
	{
		while (!IsDead)
		{
			jogador.Desenha();
			GerenciaCenarios();
			await Task.Delay(Fps);
		}
	}
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

}

