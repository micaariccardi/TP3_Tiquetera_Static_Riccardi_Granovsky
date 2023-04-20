using System.Collections.Generic;

public class Ticketera
{
    
    int[] precioTipoEntrada = {0, 15000, 30000, 10000, 40000};
    private Dictionary<int, Cliente> DicClientes = new Dictionary<int, Cliente>();
    private int ultimoIDEntrada = 0;  //aumenta antes de asignar el valor

    public int DevolverUltimoID()
    {
        return ultimoIDEntrada; //si devuelve 0 es porque tdv no se hizo ninguna entrada
    }

    public int AgregarCliente(Cliente usuario)
    {
        ultimoIDEntrada++;
        DicClientes.Add(ultimoIDEntrada, usuario);
        return ultimoIDEntrada;
    }

    public Cliente BuscarCliente(int idEntrada)
    {
        if (DicClientes.ContainsKey(idEntrada))
        {
            return DicClientes[idEntrada];
        }
        else
        {
            return null;
        }
    }

    public bool CambiarEntrada(int id, int tipoEntradaNuevo, int total) //total es lo que pagó antes
    {
        bool valido = false;
        if (precioTipoEntrada[tipoEntradaNuevo] > total)
        {
            DicClientes[id].tipoEntrada = tipoEntradaNuevo;
            DicClientes[id].totalAbonado = tipoEntradaNuevo; 
            DicClientes[id].fechaInscripcion = DateTime.Today;
            valido = true;
        }
        return valido;
    }

    public List<string> EstadisticasTicketera()
    {
        List <string> listaEstadisticas = new List<string>();
        
        if(DicClientes.Count == 0)
        {
            Console.WriteLine("AÚN NO SE ANOTÓ NADIE.");
        }
        else
        {
        listaEstadisticas.Add("CANTIDAD CLIENTES: " + listaEstadisticas.Count);

        int contadorTotal = 0, contador1 = 0, contador2 = 0, contador3 = 0, contador4 = 0;
        foreach (Cliente cliente in DicClientes.Values)
        {
            contadorTotal++;
            switch (cliente.tipoEntrada)
            {
                case 1:
                    contador1++;
                break;

                case 2:
                    contador2++;
                break;

                case 3:
                    contador3++;
                break;

                case 4:
                    contador4++;
                break;
            }
        }

        listaEstadisticas.Add("PORCENTAJE DÍA UNO: %" + CalcularPorcentaje(contadorTotal, contador1));
        listaEstadisticas.Add("PORCENTAJE DÍA DOS: %" + CalcularPorcentaje(contadorTotal, contador2));
        listaEstadisticas.Add("PORCENTAJE DÍA TRES: %" + CalcularPorcentaje(contadorTotal, contador3));
        listaEstadisticas.Add("PORCENTAJE FULL PASS: %" + CalcularPorcentaje(contadorTotal, contador4));

        listaEstadisticas.Add("RECAUDACIONES DÍA UNO: $" + precioTipoEntrada[1]*contador1);
        listaEstadisticas.Add("RECAUDACIONES DÍA DOS: $" + precioTipoEntrada[2]*contador2);
        listaEstadisticas.Add("RECAUDACIONES DÍA TRES: $" + precioTipoEntrada[3]*contador3);
        listaEstadisticas.Add("RECAUDACIONES FULL PASS: $" + precioTipoEntrada[4]*contador4);

        listaEstadisticas.Add("RECAUDACIÓN TOTAL: $" + (precioTipoEntrada[1]*contador1 + precioTipoEntrada[2]*contador2 + precioTipoEntrada[3]*contador3 + precioTipoEntrada[4]*contador4));
        }

        return listaEstadisticas;
    }

    private double CalcularPorcentaje(int total, int cant)
    {
        return cant*100/total;
    }

}