

using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using Rentacar2Gen.Infraestructure.Repository.RentaCar2;
using Rentacar2Gen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar2Gen.Infraestructure.Repository
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

public override IFacturaRepository FacturaRepository {
        get
        {
                this.facturarepository = new FacturaRepository ();
                this.facturarepository.setSessionCP (session);
                return this.facturarepository;
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

public override ILineaFacturaRepository LineaFacturaRepository {
        get
        {
                this.lineafacturarepository = new LineaFacturaRepository ();
                this.lineafacturarepository.setSessionCP (session);
                return this.lineafacturarepository;
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
}
}

