
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using Rentacar2Gen.ApplicationCore.Utils;



namespace Rentacar2Gen.ApplicationCore.CP.RentaCar2
{
public partial class FacturaCP : GenericBasicCP
{
public FacturaCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public FacturaCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
