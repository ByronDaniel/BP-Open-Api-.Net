namespace BP;

public class Cuenta
{
    public Cuenta(string? ciUsuario, string? numero, char? tipo, double? saldo)
    {
        CiUsuario = ciUsuario;
        Numero = numero;
        Tipo = tipo;
        Saldo = saldo;
    }

    public string? CiUsuario { get; set; }
    public string? Numero { get; set; }
    public char? Tipo { get; set; }
    public double? Saldo { get; set; }
}
