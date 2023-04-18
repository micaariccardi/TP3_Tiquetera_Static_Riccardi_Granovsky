public class Cliente
{
    public int dni {get; private set;}
    public string apellido {get; private set;}
    public string nombre {get; private set;}
    public DateTime fechaInscripcion {get; set;}
    public int tipoEntrada {get; set;}
    public int totalAbonado {get; set;}

    public Cliente(int DNI, string ape, string nom, DateTime fecha, int tipoE, int totalA)
    {
        dni = DNI;
        apellido = ape;
        nombre = nom;
        fechaInscripcion = fecha;
        tipoEntrada = tipoE;
        totalAbonado = totalA;
    }
}

