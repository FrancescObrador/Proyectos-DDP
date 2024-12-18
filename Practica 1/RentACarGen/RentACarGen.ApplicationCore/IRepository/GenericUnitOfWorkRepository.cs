
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarGen.ApplicationCore.IRepository.RentACar
{
public abstract class GenericUnitOfWorkRepository
{
protected IClienteRepository clienterepository;
protected IReservaRepository reservarepository;
protected ICocheRepository cocherepository;
protected IFacturaRepository facturarepository;
protected ILineaFacturaRepository lineafacturarepository;


public abstract IClienteRepository ClienteRepository {
        get;
}
public abstract IReservaRepository ReservaRepository {
        get;
}
public abstract ICocheRepository CocheRepository {
        get;
}
public abstract IFacturaRepository FacturaRepository {
        get;
}
public abstract ILineaFacturaRepository LineaFacturaRepository {
        get;
}
}
}
