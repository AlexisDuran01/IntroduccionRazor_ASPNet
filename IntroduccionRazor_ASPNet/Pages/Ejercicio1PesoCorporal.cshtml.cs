using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor_ASPNet.Pages;

public class Ejercicio1PesoCorporal : PageModel
{
    [BindProperty]
    public double Peso { get; set; }

    [BindProperty]
    public double Altura { get; set; }

    public double IMC { get; set; } = 0;
    public string Categoria { get; set; } = "";
    public string ImagenRuta { get; set; } = "";

    public bool MostrarResultado { get; set; } = false;

    public void OnPost()
    {
        if (Peso > 0 && Altura > 0)
        {
            IMC = Peso / (Altura * Altura);
            MostrarResultado = true;

            if (IMC < 18)
            {
                Categoria = "Peso Bajo";
                ImagenRuta = "imc_pesobajo.png";
            }
            else if (IMC >= 18 && IMC < 25)
            {
                Categoria = "Peso Normal";
                ImagenRuta = "imc_normal.png";
            }
            else if (IMC >= 25 && IMC < 27)
            {
                Categoria = "Sobrepeso";
                ImagenRuta = "imc_sobrepeso.png";
            }
            else if (IMC >= 27 && IMC < 30)
            {
                Categoria = "Obesidad grado I";
                ImagenRuta = "imc_obesidad1.png";
            }
            else if (IMC >= 30 && IMC < 40)
            {
                Categoria = "Obesidad grado II";
                ImagenRuta = "imc_obesidad2.png";
            }
            else // IMC >= 40
            {
                Categoria = "Obesidad grado III";
                ImagenRuta = "imc_obesidad3.png";
            }
        }
        else
        {
            MostrarResultado = false;
        }
    }
}