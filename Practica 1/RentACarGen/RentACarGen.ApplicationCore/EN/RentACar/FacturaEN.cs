
using System;
// Definición clase FacturaEN
namespace RentACarGen.ApplicationCore.EN.RentACar
{
public partial class FacturaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo esPagada
 */
private bool esPagada;



/**
 *	Atributo esAnulada
 */
private bool esAnulada;



/**
 *	Atributo total
 */
private float total;



/**
 *	Atributo lineaFactura
 */
private System.Collections.Generic.IList<RentACarGen.ApplicationCore.EN.RentACar.LineaFacturaEN> lineaFactura;



/**
 *	Atributo cliente
 */
private RentACarGen.ApplicationCore.EN.RentACar.ClienteEN cliente;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual bool EsPagada {
        get { return esPagada; } set { esPagada = value;  }
}



public virtual bool EsAnulada {
        get { return esAnulada; } set { esAnulada = value;  }
}



public virtual float Total {
        get { return total; } set { total = value;  }
}



public virtual System.Collections.Generic.IList<RentACarGen.ApplicationCore.EN.RentACar.LineaFacturaEN> LineaFactura {
        get { return lineaFactura; } set { lineaFactura = value;  }
}



public virtual RentACarGen.ApplicationCore.EN.RentACar.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}





public FacturaEN()
{
        lineaFactura = new System.Collections.Generic.List<RentACarGen.ApplicationCore.EN.RentACar.LineaFacturaEN>();
}



public FacturaEN(int id, Nullable<DateTime> fecha, bool esPagada, bool esAnulada, float total, System.Collections.Generic.IList<RentACarGen.ApplicationCore.EN.RentACar.LineaFacturaEN> lineaFactura, RentACarGen.ApplicationCore.EN.RentACar.ClienteEN cliente
                 )
{
        this.init (Id, fecha, esPagada, esAnulada, total, lineaFactura, cliente);
}


public FacturaEN(FacturaEN factura)
{
        this.init (factura.Id, factura.Fecha, factura.EsPagada, factura.EsAnulada, factura.Total, factura.LineaFactura, factura.Cliente);
}

private void init (int id
                   , Nullable<DateTime> fecha, bool esPagada, bool esAnulada, float total, System.Collections.Generic.IList<RentACarGen.ApplicationCore.EN.RentACar.LineaFacturaEN> lineaFactura, RentACarGen.ApplicationCore.EN.RentACar.ClienteEN cliente)
{
        this.Id = id;


        this.Fecha = fecha;

        this.EsPagada = esPagada;

        this.EsAnulada = esAnulada;

        this.Total = total;

        this.LineaFactura = lineaFactura;

        this.Cliente = cliente;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FacturaEN t = obj as FacturaEN;
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
