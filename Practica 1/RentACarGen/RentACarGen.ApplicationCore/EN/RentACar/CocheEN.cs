
using System;
// Definición clase CocheEN
namespace RentACarGen.ApplicationCore.EN.RentACar
{
public partial class CocheEN
{
/**
 *	Atributo id
 */
private int id;



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






public virtual int Id {
        get { return id; } set { id = value;  }
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



public CocheEN(int id, RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum categoria, RentACarGen.ApplicationCore.Enumerated.RentACar.EstadoCocheEnum estado, RentACarGen.ApplicationCore.EN.RentACar.ReservaEN reserva
               )
{
        this.init (Id, categoria, estado, reserva);
}


public CocheEN(CocheEN coche)
{
        this.init (coche.Id, coche.Categoria, coche.Estado, coche.Reserva);
}

private void init (int id
                   , RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum categoria, RentACarGen.ApplicationCore.Enumerated.RentACar.EstadoCocheEnum estado, RentACarGen.ApplicationCore.EN.RentACar.ReservaEN reserva)
{
        this.Id = id;


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
