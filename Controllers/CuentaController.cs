using Microsoft.AspNetCore.Mvc;

namespace BP.Controllers;

[ApiController]
[Route("[controller]")]
public class CuentaController : ControllerBase
{
    private static List<Cuenta> cuentas = new List<Cuenta>() { new Cuenta("1231232133", "421123412", 'A', 123.54), new Cuenta("1231232133", "421222342", 'C', 312) };
    private readonly ILogger<CuentaController> _logger;
    public CuentaController(ILogger<CuentaController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCuentas")]
    public IEnumerable<Cuenta> GetCuentas()
    {
        return cuentas;
    }

    [HttpGet("{numero:int}")]
    public Cuenta GetCuenta(string numero)
    {
        Cuenta cuentaBusqueda = null;
        foreach (Cuenta cuenta in cuentas)
        {
            if (cuenta.Numero == numero)
            {
                cuentaBusqueda = cuenta;
            }
        }
        return cuentaBusqueda;
    }

    [HttpPost]
    public void PostCuenta(Cuenta cuenta)
    {
        cuentas.Add(cuenta);
    }

    [HttpDelete("{numero:int}")]
    public void DeleteUsuario(string numero)
    {
        Cuenta cuentaSeleccionada = null;
        for (int i = 0; i < cuentas.Count; i++)
        {
            if (cuentas[i].Numero == numero)
            {
                cuentaSeleccionada = cuentas[i];
            }
        }
        if (cuentaSeleccionada != null)
        {
            cuentas.Remove(cuentaSeleccionada);
        }
    }

    [HttpPut("{numero:int}")]
    public void UpdateUsuario(string numero, Cuenta cuenta)
    {
        for (int i = 0; i < cuentas.Count; i++)
        {
            if (cuentas[i].Numero == numero)
            {
                cuenta.Numero = numero;
                cuentas[i] = cuenta;
            }
        }
    }
}
