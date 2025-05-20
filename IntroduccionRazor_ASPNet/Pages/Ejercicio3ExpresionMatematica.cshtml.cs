using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor_ASPNet.Pages;

public class Ejercicio3ExpresionMatematica : PageModel
{

    [BindProperty] public double A { get; set; }

    [BindProperty] public double B { get; set; }

    [BindProperty] public double X { get; set; }

    [BindProperty] public double Y { get; set; }

    [BindProperty] public int N { get; set; }

    public double Resultado1 { get; set; }

    public Dictionary<int, double> Iteraciones { get; set; } = new();

    
    public bool MostrarResultado { get; set; } = false;

    public void OnPost()
    {
        int n = N;
        double a = A, b = B, x = X, y = Y;

        Iteraciones.Clear();

        if (n > 0 && a > 0 && b > 0 && x > 0 && y > 0)
        {
            Resultado1 = Math.Pow(a * x + b * y, 2);
            MostrarResultado = true;

            for (int k = 0; k <= n; k++)
            {
                int coef = 1;
                for (int j = 1; j <= k; j++)
                    coef = coef * (n - j + 1) / j;

                double valor = coef * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
                Iteraciones[k] = valor;
            }
        }
        else
        {
            MostrarResultado = false;
        }
    }
}