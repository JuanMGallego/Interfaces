namespace JuanManuelGallegoGEx.Views;

public partial class Juego : ContentPage
{

    private int puntuacion = 0;
    private int errores = 0;
    private Boolean yaPulsada1 = false;
    private Boolean yaPulsada2 = false;
    private Boolean yaPulsada3 = false;

    public Juego()
	{
		InitializeComponent();


	}

    /// <summary>
    /// Evento para cuando la imagen es pulsada y se toma como fallo
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TapGestureRecognizer_Image(object sender, EventArgs e)
    {

        if (puntuacion < 3 && errores < 3)
        {

            errores++;
            erroresTxt.Text = "Errores: " + errores;

        }
        else
        {
            resultadoTxt.Opacity = 1;
        }
    }

    /// <summary>
    /// Evento para cuando la pista 1 es pulsada
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Pista1_Clicked(object sender, EventArgs e)
    {

        if (puntuacion < 3 && errores < 3 && !yaPulsada1)
        {

            yaPulsada1 = true;
            puntuacion++;
            puntuacionTxt.Text = "Puntuación: " + puntuacion;
            circulo1I.Opacity = 1;
            circulo1R.Opacity = 1;

        } else
        {
            resultadoTxt.Opacity = 1;
        }
        
    }

    /// <summary>
    /// Evento para cuando la pista 1 es pulsada
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Pista2_Clicked(object sender, EventArgs e)
    {

        if (puntuacion < 3 && errores < 3 && !yaPulsada2)
        {

            yaPulsada2 = true;
            puntuacion++;
            puntuacionTxt.Text = "Puntuación: " + puntuacion;
            circulo2I.Opacity = 1;
            circulo2R.Opacity = 1;

        }
        else
        {
            resultadoTxt.Opacity = 1;
        }

    }

    /// <summary>
    /// Evento para cuando la pista 1 es pulsada
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Pista3_Clicked(object sender, EventArgs e)
    {

        if (puntuacion < 3 && errores < 3 && !yaPulsada3) {

            yaPulsada3 = true;
            puntuacion++;
            puntuacionTxt.Text = "Puntuación: " + puntuacion;
            circulo3I.Opacity = 1;
            circulo3R.Opacity = 1;

        }
        else
        {
            resultadoTxt.Opacity = 1;
        }

    }

    /// <summary>
    /// Evento para reiniciar el juego si el usuario pulsa si
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Si_Clicked(object sender, EventArgs e)
    {

        if (puntuacion == 3)
        {
            ganaTxt.Text = "Ganador";
        } else
        {
            ganaTxt.Text = "Perdedor";
        }
        resultadoTxt.Opacity = 0;
        puntuacion = 0;
        errores = 0;
        puntuacionTxt.Text = "Puntuacion: " + puntuacion;
        erroresTxt.Text = "Errores: " + errores;

    }

    /// <summary>
    /// Evento para cerrar el juego si el usuario pulsa no
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void No_Clicked(object sender, EventArgs e)
    {

    }

}