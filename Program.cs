int[] precioTipoEntrada = {0, 15000, 30000, 10000, 40000};
List<Cliente> listaClientes = new List<Cliente>();
List<string> listaEstadisticas = new List<string>();
Ticketera ticketera = new Ticketera();

Console.WriteLine("MENSAJE CON OPCIONES :)");
int opcion = IngresarEnteroRango(1, 5, "INGRESE OPCIÓN: ");
Console.Clear();
while(opcion!=5)
{
    switch(opcion)
    {
        case 1:
            
            listaClientes.Add(CargarCliente());
        break;
        case 2:
            listaEstadisticas = ticketera.EstadisticasTicketera();
            for (int i = 0, largo = listaEstadisticas.Count; i < largo; i++)
            {
                Console.WriteLine("- " + listaEstadisticas[i]);
            }
        break;
        case 3:
            int id = IngresarEnteroPositivo("INGRESE ID: ");
            Cliente busqueda = ticketera.BuscarCliente(id);

            if (busqueda == null)
            {
                Console.WriteLine("LOS DATOS DE ESE CLIENTE NO ESTÁN CARGADOS.");
            }
            else
            {
                // (int DNI, string ape, string nom, DateTime fecha, int tipoE, int totalA)
                Console.WriteLine("DNI: " + busqueda.dni);
                Console.WriteLine("APELLIDO: " + busqueda.apellido);
                Console.WriteLine("NOMBRE: " + busqueda.nombre);
                Console.WriteLine("FECHA DE INSCRIPCIÓN: " + busqueda.fechaInscripcion);
                Console.WriteLine("TIPO DE ENTRADA: " + busqueda.tipoEntrada);
                Console.WriteLine("TOTAL ABONADO: " + busqueda.totalAbonado);
            }            
        break;
        case 4:
        break;
    }
}

Cliente CargarCliente()
{
    Console.Clear();

    int dni = IngresarEnteroPositivo("INGRESE DNI: ");
    string apellido = IngresarSoloCaracteres("INGRESE APELLIDO: ");
    string nombre = IngresarSoloCaracteres("INGRESE NOMBRE: ");
    DateTime hoy = DateTime.Today;
    int tipoEntrada = IngresarEnteroRango(1, 5, "INGRESE TIPO ENTRADA: ");
    int total = precioTipoEntrada[tipoEntrada];

    Cliente cliente = new Cliente(dni, apellido, nombre, hoy, tipoEntrada, total); 
    return cliente;
}

string IngresarSoloCaracteres(string mensaje)
{
    string ingreso;
    do
    {
        Console.Write(mensaje);
        ingreso = Console.ReadLine();
    }
    while(!SoloCaracteres(ingreso));
    return ingreso;
}

bool SoloCaracteres(string texto)
{
    bool valido = true;
    texto = texto.ToUpper();
    int i = 0, largo = texto.Length;
    do
    {
        if (texto[i] < 'A' || texto[i] > 'Z')
        {
            valido = false;
        }
    }
    while (valido && i<largo);
    return valido;
}

int IngresarEnteroPositivo(string mensaje)
{
    int ingreso;
    do
    {
        Console.Write(mensaje);
        ingreso = int.Parse(Console.ReadLine());
    }
    while (ingreso < 0);
    return ingreso;
}

int IngresarEnteroRango(int min, int max, string mensaje)
{
    int ingreso;
    do
    {
        Console.Write(mensaje);
        ingreso = int.Parse(Console.ReadLine());
    }
    while (ingreso < min || ingreso > max);
    return ingreso;
}
