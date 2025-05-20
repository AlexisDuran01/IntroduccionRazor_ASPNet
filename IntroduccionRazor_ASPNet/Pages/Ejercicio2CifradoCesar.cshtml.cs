using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace IntroduccionRazor_ASPNet.Pages
{
    public class Ejercicio2CifradoCesar : PageModel
    {
        [BindProperty]
        public string Texto { get; set; } = "";

        [BindProperty]
        public int Desplazamiento { get; set; }

        [BindProperty]
        public string Operacion { get; set; } = "Cifrar";

        public string Resultado { get; set; } = "";

        public bool MostrarResultado { get; set; } = false;

        private readonly char[] Alfabeto = new char[]
        {
            'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (string.IsNullOrWhiteSpace(Texto) || Desplazamiento <= 0)
            {
                MostrarResultado = false;
                return;
            }

            string textoMayus = Texto.ToUpper();

            int n = Desplazamiento % Alfabeto.Length;
            if (n == 0) n = Alfabeto.Length;

            StringBuilder sb = new StringBuilder();

            foreach (char c in textoMayus)
            {
                if (c == ' ')
                {
                    // conservar espacios
                    sb.Append(' ');
                    continue;
                }

                // Buscar el índice de la letra actual en el alfabeto
                int index = -1;
                for (int i = 0; i < Alfabeto.Length; i++)
                {
                    if (Alfabeto[i] == c)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    sb.Append(c);
                    continue;
                }

                int nuevoIndex = 0;
                switch (Operacion)
                {
                    case "Cifrar":
                        nuevoIndex = (index + n) % Alfabeto.Length;
                        break;
                    case "Descifrar":
                        nuevoIndex = (index - n);
                        if (nuevoIndex < 0) nuevoIndex += Alfabeto.Length;
                        break;
                    default:
                        nuevoIndex = index; 
                        break;
                }

                sb.Append(Alfabeto[nuevoIndex]);
            }

            Resultado = sb.ToString();
            MostrarResultado = true;
        }
    }
}
