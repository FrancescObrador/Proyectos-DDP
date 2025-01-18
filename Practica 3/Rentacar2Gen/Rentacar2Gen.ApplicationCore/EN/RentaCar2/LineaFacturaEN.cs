
using System;
// Definición clase LineaFacturaEN
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public partial class LineaFacturaEN
{
/**
 *	Atributo factura
 */
private Rentacar2Gen.ApplicationCore.EN.RentaCar2.FacturaEN factura;



/**
 *	Atributo numLinea
 */
private int numLinea;



/**
 *	Atributo reserva
 */
private Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN reserva;



/**
 *	Atributo precio
 */
private double precio;






public virtual Rentacar2Gen.ApplicationCore.EN.RentaCar2.FacturaEN Factura {
        get { return factura; } set { factura = value;  }
}



public virtual int NumLinea {
        get { return numLinea; } set { numLinea = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN Reserva {
        get { return reserva; } set { reserva = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}





public LineaFacturaEN()
{
}



public LineaFacturaEN(int numLinea, Rentacar2Gen.ApplicationCore.EN.RentaCar2.FacturaEN factura, Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN reserva, double precio
                      )
{
        this.init (NumLinea, factura, reserva, precio);
}


public LineaFacturaEN(LineaFacturaEN lineaFactura)
{
        this.init (lineaFactura.NumLinea, lineaFactura.Factura, lineaFactura.Reserva, lineaFactura.Precio);
}

private void init (int numLinea
                   , Rentacar2Gen.ApplicationCore.EN.RentaCar2.FacturaEN factura, Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN reserva, double precio)
{
        this.NumLinea = numLinea;


        this.Factura = factura;

        this.Reserva = reserva;

        this.Precio = precio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaFacturaEN t = obj as LineaFacturaEN;
        if (t == null)
                return false;
        if (NumLinea.Equals (t.NumLinea))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.NumLinea.GetHashCode ();
        return hash;
}
}
}
