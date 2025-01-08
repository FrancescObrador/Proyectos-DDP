

using System;
using System.Text;
using System.Collections.Generic;

using RentACarGen.ApplicationCore.Exceptions;

using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;


namespace RentACarGen.ApplicationCore.CEN.RentACar
{
/*
 *      Definition of the class FacturaCEN
 *
 */
public partial class FacturaCEN
{
private IFacturaRepository _IFacturaRepository;

public FacturaCEN(IFacturaRepository _IFacturaRepository)
{
        this._IFacturaRepository = _IFacturaRepository;
}

public IFacturaRepository get_IFacturaRepository ()
{
        return this._IFacturaRepository;
}

public int CrearFactura (Nullable<DateTime> p_fecha, bool p_esPagada, bool p_esAnulada, float p_total, string p_cliente)
{
        FacturaEN facturaEN = null;
        int oid;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Fecha = p_fecha;

        facturaEN.EsPagada = p_esPagada;

        facturaEN.EsAnulada = p_esAnulada;

        facturaEN.Total = p_total;


        if (p_cliente != null) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                facturaEN.Cliente = new RentACarGen.ApplicationCore.EN.RentACar.ClienteEN ();
                facturaEN.Cliente.DNI = p_cliente;
        }



        oid = _IFacturaRepository.CrearFactura (facturaEN);
        return oid;
}

public void ModificarFactura (int p_Factura_OID, Nullable<DateTime> p_fecha, bool p_esPagada, bool p_esAnulada, float p_total)
{
        FacturaEN facturaEN = null;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Id = p_Factura_OID;
        facturaEN.Fecha = p_fecha;
        facturaEN.EsPagada = p_esPagada;
        facturaEN.EsAnulada = p_esAnulada;
        facturaEN.Total = p_total;
        //Call to FacturaRepository

        _IFacturaRepository.ModificarFactura (facturaEN);
}

public FacturaEN DamePorOID (int id
                             )
{
        FacturaEN facturaEN = null;

        facturaEN = _IFacturaRepository.DamePorOID (id);
        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> list = null;

        list = _IFacturaRepository.DameTodos (first, size);
        return list;
}
}
}
