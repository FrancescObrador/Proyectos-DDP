
using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public abstract class GenericUnitOfWorkRepository
{
protected IClienteRepository clienterepository;
protected IFacturaRepository facturarepository;
protected IReservaRepository reservarepository;
protected ILineaFacturaRepository lineafacturarepository;
protected ICocheRepository cocherepository;


public abstract IClienteRepository ClienteRepository {
        get;
}
public abstract IFacturaRepository FacturaRepository {
        get;
}
public abstract IReservaRepository ReservaRepository {
        get;
}
public abstract ILineaFacturaRepository LineaFacturaRepository {
        get;
}
public abstract ICocheRepository CocheRepository {
        get;
}
}
}
