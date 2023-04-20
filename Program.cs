int[] precioTipoEntrada = {0, 15000, 30000, 10000, 40000};
List<Cliente> listaClientes = new List<Cliente>();
List<string> listaEstadisticas = new List<string>();
Ticketera ticketera = new Ticketera();

const string MENSAJE_OPCIONES = "1. NUEVA INSCRIPCIÓN.\n2. OBTENER ESTADÍSTICAS DEL EVENTO.\n3. BUSCAR CLIENTE.\n4. CAMBIAR ENTRADA DE UN CLIENTE\n5. SALIR.";

Console.WriteLine(MENSAJE_OPCIONES);
int opcion = IngresarEnteroRango(1, 5, "INGRESE OPCIÓN: ");
Console.Clear();
while(opcion != 5)
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
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("DNI: " + busqueda.dni);
                Console.WriteLine("APELLIDO: " + busqueda.apellido);
                Console.WriteLine("NOMBRE: " + busqueda.nombre);
                Console.WriteLine("FECHA DE INSCRIPCIÓN: " + busqueda.fechaInscripcion);
                Console.WriteLine("TIPO DE ENTRADA: " + busqueda.tipoEntrada);
                Console.WriteLine("TOTAL ABONADO: " + busqueda.totalAbonado);
            }            
        break;
        case 4:
        id = IngresarId("INGRESE EL ID DE LA ENTRADA: ");
        int tipoEntrada = IngresarEnteroRango(1, 4, "INGRESE EL TIPO DE ENTRADA NUEVO: ");
        Cliente usuario = ticketera.BuscarCliente(id);
        if (ticketera.CambiarEntrada(id, tipoEntrada, usuario.totalAbonado))
        {
            Console.WriteLine("LA ENTRADA HA SIDO CAMBIADA CON ÉXITO.");
        }
        else
        {
            Console.WriteLine("LA ENTRADA NO SE HA PODIDO CAMBIAR.");
        }
        break;
    }
    Console.WriteLine(MENSAJE_OPCIONES);
    opcion = IngresarEnteroRango(1, 5, "INGRESE OPCIÓN: ");
}

int IngresarId(string mensaje)
{
    int input;
    do
    {
        Console.Write(mensaje);
        input = int.Parse(Console.ReadLine());
    }
    while (ticketera.BuscarCliente(input) == null);
    return input;
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
    ticketera.AgregarCliente(cliente);
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
    while (!SoloCaracteres(ingreso));
    return ingreso;
}

bool SoloCaracteres(string texto)
{
    bool valido = true;    
    for (int i = 0, largo = texto.Length; i < largo; i++)
    {
        if (!Char.IsLetter(texto[i]))
        {
            valido = false;
        }
    }
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
