
using System;
// Definición clase ReservaEN
namespace RentACarGen.ApplicationCore.EN.RentACar
{
public partial class ReservaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo inicio
 */
private Nullable<DateTime> inicio;



/**
 *	Atributo final
 */
private Nullable<DateTime> final;



/**
 *	Atributo cliente
 */
private RentACarGen.ApplicationCore.EN.RentACar.ClienteEN cliente;



/**
 *	Atributo lineaFactura
 */
private RentACarGen.ApplicationCore.EN.RentACar.LineaFacturaEN lineaFactura;



/**
 *	Atributo coche
 */
private RentACarGen.ApplicationCore.EN.RentACar.CocheEN coche;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Inicio {
        get { return inicio; } set { inicio = value;  }
}



public virtual Nullable<DateTime> Final {
        get { return final; } set { final = value;  }
}



public virtual RentACarGen.ApplicationCore.EN.RentACar.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual RentACarGen.ApplicationCore.EN.RentACar.LineaFacturaEN LineaFactura {
        get { return lineaFactura; } set { lineaFactura = value;  }
}



public virtual RentACarGen.ApplicationCore.EN.RentACar.CocheEN Coche {
        get { return coche; } set { coche = value;  }
}





public ReservaEN()
{
}



public ReservaEN(int id, Nullable<DateTime> inicio, Nullable<DateTime> final, RentACarGen.ApplicationCore.EN.RentACar.ClienteEN cliente, RentACarGen.ApplicationCore.EN.RentACar.LineaFacturaEN lineaFactura, RentACarGen.ApplicationCore.EN.RentACar.CocheEN coche
                 )
{
        this.init (Id, inicio, final, cliente, lineaFactura, coche);
}


public ReservaEN(ReservaEN reserva)
{
        this.init (reserva.Id, reserva.Inicio, reserva.Final, reserva.Cliente, reserva.LineaFactura, reserva.Coche);
}

private void init (int id
                   , Nullable<DateTime> inicio, Nullable<DateTime> final, RentACarGen.ApplicationCore.EN.RentACar.ClienteEN cliente, RentACarGen.ApplicationCore.EN.RentACar.LineaFacturaEN lineaFactura, RentACarGen.ApplicationCore.EN.RentACar.CocheEN coche)
{
        this.Id = id;


        this.Inicio = inicio;

        this.Final = final;

        this.Cliente = cliente;

        this.LineaFactura = lineaFactura;

        this.Coche = coche;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ReservaEN t = obj as ReservaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
