

using RentACarGen.ApplicationCore.IRepository.RentACar;
using RentACarGen.Infraestructure.Repository.RentACar;
using RentACarGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IClienteRepository ClienteRepository {
        get
        {
                this.clienterepository = new ClienteRepository ();
                this.clienterepository.setSessionCP (session);
                return this.clienterepository;
        }
}

public override IReservaRepository ReservaRepository {
        get
        {
                this.reservarepository = new ReservaRepository ();
                this.reservarepository.setSessionCP (session);
                return this.reservarepository;
        }
}

public override ICocheRepository CocheRepository {
        get
        {
                this.cocherepository = new CocheRepository ();
                this.cocherepository.setSessionCP (session);
                return this.cocherepository;
        }
}

public override IFacturaRepository FacturaRepository {
        get
        {
                this.facturarepository = new FacturaRepository ();
                this.facturarepository.setSessionCP (session);
                return this.facturarepository;
        }
}

public override ILineaFacturaRepository LineaFacturaRepository {
        get
        {
                this.lineafacturarepository = new LineaFacturaRepository ();
                this.lineafacturarepository.setSessionCP (session);
                return this.lineafacturarepository;
        }
}
}
}

