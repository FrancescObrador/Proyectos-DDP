
using System;
// Definición clase CocheEN
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public partial class CocheEN
{
/**
 *	Atributo reserva
 */
private Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN reserva;



/**
 *	Atributo numLicencia
 */
private int numLicencia;



/**
 *	Atributo categoria
 */
private Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.CategoriaCocheEnum categoria;



/**
 *	Atributo estado
 */
private Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoCocheEnum estado;



/**
 *	Atributo precioDia
 */
private float precioDia;






public virtual Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN Reserva {
        get { return reserva; } set { reserva = value;  }
}



public virtual int NumLicencia {
        get { return numLicencia; } set { numLicencia = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.CategoriaCocheEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoCocheEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual float PrecioDia {
        get { return precioDia; } set { precioDia = value;  }
}





public CocheEN()
{
}



public CocheEN(int numLicencia, Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN reserva, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.CategoriaCocheEnum categoria, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoCocheEnum estado, float precioDia
               )
{
        this.init (NumLicencia, reserva, categoria, estado, precioDia);
}


public CocheEN(CocheEN coche)
{
        this.init (coche.NumLicencia, coche.Reserva, coche.Categoria, coche.Estado, coche.PrecioDia);
}

private void init (int numLicencia
                   , Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN reserva, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.CategoriaCocheEnum categoria, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoCocheEnum estado, float precioDia)
{
        this.NumLicencia = numLicencia;


        this.Reserva = reserva;

        this.Categoria = categoria;

        this.Estado = estado;

        this.PrecioDia = precioDia;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CocheEN t = obj as CocheEN;
        if (t == null)
                return false;
        if (NumLicencia.Equals (t.NumLicencia))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.NumLicencia.GetHashCode ();
        return hash;
}
}
}
