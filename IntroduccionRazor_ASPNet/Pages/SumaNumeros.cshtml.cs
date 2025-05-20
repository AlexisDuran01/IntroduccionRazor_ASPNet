using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor_ASPNet.Pages;

public class SumaNumeros : PageModel
{
    // Definimos los atributos
    [BindProperty] 
    public string num1 { get; set; } = "";
    [BindProperty]
    public string num2 { get; set; } = "";

    public int resultado { get; set; } = 0;
    
    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        //Recibir los datos del formulario
        int numero1 = Convert.ToInt32(num1);
        int numero2 = Convert.ToInt32(num2);
        resultado = numero1 + numero2;
        ModelState.Clear();
        
    }
    
}