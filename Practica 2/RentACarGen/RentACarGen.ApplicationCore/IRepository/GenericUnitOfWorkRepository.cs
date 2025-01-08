
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarGen.ApplicationCore.IRepository.RentACar
{
public abstract class GenericUnitOfWorkRepository
{
protected IClienteRepository clienterepository;
protected IReservaRepository reservarepository;
protected ILineaFacturaRepository lineafacturarepository;
protected IFacturaRepository facturarepository;
protected ICocheRepository cocherepository;


public abstract IClienteRepository ClienteRepository {
        get;
}
public abstract IReservaRepository ReservaRepository {
        get;
}
public abstract ILineaFacturaRepository LineaFacturaRepository {
        get;
}
public abstract IFacturaRepository FacturaRepository {
        get;
}
public abstract ICocheRepository CocheRepository {
        get;
}
}
}
