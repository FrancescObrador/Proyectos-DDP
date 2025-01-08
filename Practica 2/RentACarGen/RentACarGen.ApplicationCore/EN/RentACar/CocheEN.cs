
using System;
// Definición clase CocheEN
namespace RentACarGen.ApplicationCore.EN.RentACar
{
public partial class CocheEN
{
/**
 *	Atributo numLicencia
 */
private int numLicencia;



/**
 *	Atributo categoria
 */
private RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum categoria;



/**
 *	Atributo estado
 */
private RentACarGen.ApplicationCore.Enumerated.RentACar.EstadoCocheEnum estado;



/**
 *	Atributo reserva
 */
private RentACarGen.ApplicationCore.EN.RentACar.ReservaEN reserva;






public virtual int NumLicencia {
        get { return numLicencia; } set { numLicencia = value;  }
}



public virtual RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual RentACarGen.ApplicationCore.Enumerated.RentACar.EstadoCocheEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual RentACarGen.ApplicationCore.EN.RentACar.ReservaEN Reserva {
        get { return reserva; } set { reserva = value;  }
}





public CocheEN()
{
}



public CocheEN(int numLicencia, RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum categoria, RentACarGen.ApplicationCore.Enumerated.RentACar.EstadoCocheEnum estado, RentACarGen.ApplicationCore.EN.RentACar.ReservaEN reserva
               )
{
        this.init (NumLicencia, categoria, estado, reserva);
}


public CocheEN(CocheEN coche)
{
        this.init (coche.NumLicencia, coche.Categoria, coche.Estado, coche.Reserva);
}

private void init (int numLicencia
                   , RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum categoria, RentACarGen.ApplicationCore.Enumerated.RentACar.EstadoCocheEnum estado, RentACarGen.ApplicationCore.EN.RentACar.ReservaEN reserva)
{
        this.NumLicencia = numLicencia;


        this.Categoria = categoria;

        this.Estado = estado;

        this.Reserva = reserva;
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
