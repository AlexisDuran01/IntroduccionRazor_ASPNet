using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor_ASPNet.Pages;

public class Ejercicio4NumerosAleatorios : PageModel
{
    public int[] NumerosAleatorios { get; set; } = new int[20];
    public int[] NumerosOrdenados { get; set; } = new int[20];
    
    public int Suma { get; set; }
    public double Promedio { get; set; }
    public List<int> Modas { get; set; } = new List<int>();
    public double Mediana { get; set; }
    public double limiteInferior { get; set; }
    public double limiteSuperior { get; set; }



    public void OnGet()
    {
       
        Random random = new Random();
        for (int i = 0; i < NumerosAleatorios.Length; i++)
        {
            NumerosAleatorios[i] = random.Next(1, 101);
        }
        
        Array.Copy(NumerosAleatorios, NumerosOrdenados, NumerosAleatorios.Length);
        Array.Sort(NumerosOrdenados);
        
        Suma = NumerosAleatorios.Sum();
        Promedio = NumerosAleatorios.Average();

        // Calcular la moda básica
        int maxCuenta = 0;

        for (int i = 0; i < NumerosAleatorios.Length; i++)
        {
            int cuenta = 0;
            for (int j = 0; j < NumerosAleatorios.Length; j++)
            {
                if (NumerosAleatorios[j] == NumerosAleatorios[i])
                {
                    cuenta++;
                }
            }

            if (cuenta > maxCuenta)
            {
                maxCuenta = cuenta;
            }
        }

        if (maxCuenta > 1)
        {
            for (int i = 0; i < NumerosAleatorios.Length; i++)
            {
                int cuenta = 0;
                for (int j = 0; j < NumerosAleatorios.Length; j++)
                {
                    if (NumerosAleatorios[j] == NumerosAleatorios[i])
                    {
                        cuenta++;
                    }
                }

                if (cuenta == maxCuenta && !Modas.Contains(NumerosAleatorios[i]))
                {
                    Modas.Add(NumerosAleatorios[i]);
                }
            }
            Modas.Sort();
        }
        

        int mitad = NumerosOrdenados.Length / 2;
        
        if (NumerosOrdenados.Length % 2 == 0)
        {
            limiteInferior= NumerosOrdenados[mitad - 1];
            limiteSuperior= NumerosOrdenados[mitad];
            Mediana = (limiteInferior + limiteSuperior) / 2.0;
        }
        else
        {
            Mediana = NumerosOrdenados[mitad];
        }

    }
}