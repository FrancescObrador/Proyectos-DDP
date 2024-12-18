

using System;
using System.Text;
using System.Collections.Generic;

using RentACarGen.ApplicationCore.Exceptions;

using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;


namespace RentACarGen.ApplicationCore.CEN.RentACar
{
/*
 *      Definition of the class LineaFacturaCEN
 *
 */
public partial class LineaFacturaCEN
{
private ILineaFacturaRepository _ILineaFacturaRepository;

public LineaFacturaCEN(ILineaFacturaRepository _ILineaFacturaRepository)
{
        this._ILineaFacturaRepository = _ILineaFacturaRepository;
}

public ILineaFacturaRepository get_ILineaFacturaRepository ()
{
        return this._ILineaFacturaRepository;
}

public int New_ (double p_precio, int p_factura, int p_reserva)
{
        LineaFacturaEN lineaFacturaEN = null;
        int oid;

        //Initialized LineaFacturaEN
        lineaFacturaEN = new LineaFacturaEN ();
        lineaFacturaEN.Precio = p_precio;


        if (p_factura != -1) {
                // El argumento p_factura -> Property factura es oid = false
                // Lista de oids numLinea
                lineaFacturaEN.Factura = new RentACarGen.ApplicationCore.EN.RentACar.FacturaEN ();
                lineaFacturaEN.Factura.Id = p_factura;
        }


        if (p_reserva != -1) {
                // El argumento p_reserva -> Property reserva es oid = false
                // Lista de oids numLinea
                lineaFacturaEN.Reserva = new RentACarGen.ApplicationCore.EN.RentACar.ReservaEN ();
                lineaFacturaEN.Reserva.Id = p_reserva;
        }



        oid = _ILineaFacturaRepository.New_ (lineaFacturaEN);
        return oid;
}
}
}
